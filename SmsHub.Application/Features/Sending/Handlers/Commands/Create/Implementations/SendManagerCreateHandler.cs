using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SmsHub.Application.Common.Base;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Template.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Services.Contracts;
using Hangfire;
using System.Transactions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Domain.Features.Entities;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos.ApplicationUser;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    internal sealed class SendManagerCreateHandler : ISendManagerCreateHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMessageBatchCommandService _messageBatchCommandService;
        private readonly ITemplateQueryService _templateQueryService;
        private readonly ILineQueryService _lineQueryService;
        private readonly IProviderQueryService _providerQueryService;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly ISendInBackgroundService _sendInBackgroundService;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;


        private readonly string _Mobile = "mobile";
        public SendManagerCreateHandler(
            IUnitOfWork uow,
            IHttpContextAccessor contextAccessor,
            ITemplateGetSingleHandler templateGetSingleHandler,
            ILineGetSingleHandler lineGetSingleHandler,
            IMessageBatchCommandService messageBatchCommandService,
            IProviderGetSingleHandler providerGetSingleHandler,
            ITemplateQueryService templateQueryService,
            ILineQueryService lineQueryService,
            IProviderQueryService providerQueryService,
            ISmsProviderFactory smsProviderFactory,
            ISendInBackgroundService sendInBackgroundService,
            IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));

            _messageBatchCommandService = messageBatchCommandService;
            _messageBatchCommandService.NotNull(nameof(messageBatchCommandService));

            _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));

            _providerQueryService = providerQueryService;
            _providerQueryService.NotNull(nameof(providerQueryService));

            _smsProviderFactory = smsProviderFactory;
            _smsProviderFactory.NotNull(nameof(smsProviderFactory));

            _sendInBackgroundService = sendInBackgroundService;
            _sendInBackgroundService.NotNull(nameof(sendInBackgroundService));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(_informativeLogCreateHandler));
        }

        public async Task<ICollection<MobileText>> Handle(int templateId, int lineId, IAppUser currentUser, CancellationToken cancellationToken)
        {
            Entities.Line line = await _lineQueryService.GetIncludeProvider(lineId);
            Entities.Template template = await _templateQueryService.Get(templateId);

            Dictionary<string, string> templateDictionary = GetTemplateDictionary(template.Parameters);
            ICollection<Dictionary<string, string>> requestBodyDictionaries = await GetRequestBodyDictionaries();
            Validate(requestBodyDictionaries, templateDictionary);

            ICollection<MobileText> mobileText = GetMobileTexts(requestBodyDictionaries, template.Expression);
            MessageBatch messageBatch = MessageBatchFactory.Create(mobileText, lineId, line.Provider.BatchSize, string.Empty);
            await SaveAndEnqueue(messageBatch, line.Provider.Id, template.Title, currentUser, cancellationToken);

            return mobileText;
        }

        private async Task SaveAndEnqueue(MessageBatch messageBatch, ProviderEnum providerId, string templateTitle, IAppUser currentUser, CancellationToken cancellationToken)
        {
            using (var transaction = TransactionBuilder.Create(2, 0, IsolationLevel.ReadUncommitted))
            {
                await AddInformativeLog(messageBatch.AllSize, templateTitle, currentUser, cancellationToken);
                await _messageBatchCommandService.Add(messageBatch);
                //messageBatch.MessagesHolders
                //.ForEach(m => BackgroundJob.Enqueue(() => Console.WriteLine("this is a man, world")));
                messageBatch.MessagesHolders
                .ForEach(m => BackgroundJob.Enqueue(() => _sendInBackgroundService.Trigger(m.Id, providerId)));
                await _uow.SaveChangesAsync();
                transaction.Complete();
            }
        }     
        private void Validate(ICollection<Dictionary<string, string>> requestBodyDictionaries, Dictionary<string, string> templateDictionary)
        {
            requestBodyDictionaries.ForEach(item => Validate(templateDictionary, item));
            void Validate(Dictionary<string, string> template, Dictionary<string, string> requestBody)
            {
                if (!requestBody.Keys.Select(k => k.ToLowerInvariant()).Contains(_Mobile))
                    throw new InvalidMobileException();

                if (!ValidationAnsiString.CheckPersianPhoneNumber(FindMobileUser(requestBody)))
                    throw new InvalidMobileException();

                foreach (var item in template.Keys)
                {
                    if (!requestBody.ContainsKey(item))
                        throw new InvalidUserDataException();
                }
            }
        }
        private string FindMobileUser(Dictionary<string, string> requestBodyItem)
        {
            var mobileData = requestBodyItem.Where(x => x.Key.ToLower() == _Mobile).FirstOrDefault().Value;
            return mobileData;
        }
        private Dictionary<string, string> GetTemplateDictionary(string templateParameters)
        {           
            Dictionary<string, string> templateValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(templateParameters);
            if (templateValue == null)
                throw new InvalidTemplateException();

            return templateValue;
        }
        private async Task<ICollection<Dictionary<string, string>>> GetRequestBodyDictionaries()
        {
            var requestBody = await new StreamReader(_contextAccessor.HttpContext.Request.Body).ReadToEndAsync();
            ICollection<Dictionary<string, string>> requestBodyDictionary= JsonConvert.DeserializeObject<ICollection<Dictionary<string, string>>>(requestBody);
            return requestBodyDictionary;
        }
        private ICollection<MobileText> GetMobileTexts(ICollection<Dictionary<string, string>> requestBodyDictionaries, string templateExpression)
        {
            ICollection<MobileText> mobileTexts = new List<MobileText>();
            requestBodyDictionaries.ForEach(item => mobileTexts.Add(GetMobileText(item, templateExpression)));
            return mobileTexts;

            MobileText GetMobileText(Dictionary<string, string> requestBodyValue, string templateExpression)
            {
                string messageToSend = GetMessageText(requestBodyValue, templateExpression);
                var mobileText = new MobileText()
                {
                    Text = messageToSend,
                    Mobile = FindMobileUser(requestBodyValue)
                };
                return mobileText;
            }

            string GetMessageText(Dictionary<string, string> data, string stringTemplate)
            {
                foreach (KeyValuePair<string, string> item in data)
                {
                    stringTemplate = stringTemplate.ReplaceCurlyBrace(item.Key, item.Value);
                }
                return stringTemplate;
            }
        }
        private async Task AddInformativeLog(int count, string templateTitle, IAppUser currentUser, CancellationToken cancellationToken)
        {
            string description = $"ارسال {count} پیامک با استفاده از قالب {templateTitle}";
            CreateInformativeLogDto createInformativeLogDto = new(LogLevelEnum.Send, "پیامک", description, currentUser.UserId, currentUser.FullName);
            await _informativeLogCreateHandler.Handle(createInformativeLogDto, cancellationToken);            
        }
    }
}