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

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class SendManagerCreateHandler : ISendManagerCreateHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMessageBatchCommandService _messageBatchCommandService;
        private readonly ITemplateQueryService _templateQueryService;
        private readonly ILineQueryService _lineQueryService;
        private readonly IProviderQueryService _providerQueryService;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly ISendInBackgroundService _sendInBackgroundService;


        private readonly string _Mobile = "mobile";
        public SendManagerCreateHandler(
            IHttpContextAccessor contextAccessor,
            ITemplateGetSingleHandler templateGetSingleHandler,
            ILineGetSingleHandler lineGetSingleHandler,
            IMessageBatchCommandService messageBatchCommandService,
            IProviderGetSingleHandler providerGetSingleHandler,
            ITemplateQueryService templateQueryService,
            ILineQueryService lineQueryService,
            IProviderQueryService providerQueryService,
            ISmsProviderFactory smsProviderFactory,
            ISendInBackgroundService sendInBackgroundService
            )
        {
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
        }

        public async Task<ICollection<MobileText>> Handle(int templateId, int lineId, CancellationToken cancellationToken)
        {
            Dictionary<string,string> templateValue = await GetTemplateProperty(templateId);
            Entities.Line line = await GetLine(lineId);
            int batchSize = line.Provider.BatchSize;
            ICollection<Dictionary<string,string>> requestBodyValue = await GetRequestBodyValue();
            requestBodyValue.ToList().ForEach(r => ValidationData(templateValue, r));

            ICollection<MobileText> mobileText = new List<MobileText>();
            foreach (var item in requestBodyValue)
            {
                mobileText.Add(await GetMessageToSend(item, templateId));
            }

            var messageBatch = MessageBatchFactory.Create(mobileText, lineId, batchSize, "");
            await _messageBatchCommandService.Add(messageBatch);
            messageBatch.MessagesHolders
                .ForEach(m => BackgroundJob.Schedule(() => _sendInBackgroundService.Trigger(m.Id, line.Provider.Id),TimeSpan.FromHours(1)));
            return mobileText;
        }
        private Dictionary<string, string> DeserializeToDictionary(string data)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            }
            catch
            {
                throw new InvalidDataException();
            }
            return result;
        }
        private ICollection<Dictionary<string, string>> DeserializeToCollectionDictionary(string data)
        {
            ICollection<Dictionary<string, string>> result;
            try
            {
                result = JsonConvert.DeserializeObject<ICollection<Dictionary<string, string>>>(data);
            }
            catch
            {
                throw new InvalidDataException();
            }
            return result;
        }
        private string CreateMessageToSend(Dictionary<string, string> data, string stringTemplate)
        {
            foreach (var item in data)
            {
                stringTemplate = stringTemplate.ReplaceCurlyBrace(item.Key, item.Value);
            }
            return stringTemplate;
        }
        private void ValidationData(Dictionary<string, string> template, Dictionary<string, string> requestBody)
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
        private string FindMobileUser(Dictionary<string, string> requestBody)
        {
            var mobileData = requestBody.Where(x => x.Key.ToLower() == _Mobile).FirstOrDefault().Value;
            return mobileData;
        }
        private async Task<Entities.Template> GetTemplateById(int templateId)
        {
            var template = await _templateQueryService.Get(templateId);

            return template;
        }
        private async Task<Dictionary<string, string>> GetTemplateProperty(int templateId)
        {
            var template = await GetTemplateById(templateId);
            var templateValue = DeserializeToDictionary(template.Parameters);

            if (templateValue == null)
                throw new InvalidTemplateException();

            return templateValue;
        }
        private async Task<Entities.Line> GetLine(int lineId)
        {
            var line = await _lineQueryService.GetIncludeProvider(lineId);
            if (line == null)
                throw new InvalidLineException();

            return line;
        }
        private async Task<ICollection<Dictionary<string, string>>> GetRequestBodyValue()
        {
            var requestBody = await new StreamReader(_contextAccessor.HttpContext.Request.Body).ReadToEndAsync();
            var requestBodyValue = DeserializeToCollectionDictionary(requestBody);

            return requestBodyValue;
        }
        private async Task<MobileText> GetMessageToSend(Dictionary<string, string> requestBodyValue, int templateId)
        {
            var template = await GetTemplateById(templateId);
            string messageToSend = CreateMessageToSend(requestBodyValue, template.Expression);

            var mobileText = new MobileText()
            {
                Text = messageToSend,
                Mobile = FindMobileUser(requestBodyValue)
            };

            return mobileText;
        }
    }
}