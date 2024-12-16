using Azure.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SmsHub.Application.Common.Base;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Sending.Services;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using System.Collections.Immutable;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class SendManagerCreateHandler : ISendManagerCreateHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        private readonly ILineGetSingleHandler _lineGetSingleHandler;
        private readonly IMessageBatchCommandService _messageBatchCommandService;
        private readonly string _Mobile = "Mobile";
        public SendManagerCreateHandler(IHttpContextAccessor contextAccessor
            ,ITemplateGetSingleHandler templateGetSingleHandler
            , ILineGetSingleHandler lineGetSingleHandler
            ,IMessageBatchCommandService messageBatchCommandService
)
        {
            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));

            _templateGetSingleHandler = templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));

            _lineGetSingleHandler = lineGetSingleHandler;
            _lineGetSingleHandler.NotNull(nameof(lineGetSingleHandler));

            _messageBatchCommandService = messageBatchCommandService;
            _messageBatchCommandService.NotNull(nameof(messageBatchCommandService));
        }

        public async Task<ICollection<MobileText>> Handle(int templateId, int lineId, int batchSize, CancellationToken cancellationToken)
        {
            var templateValue = await GetTemplateProperty(templateId);
            var lineNumber = await GetLineNumber(lineId);
            var requestBodyValue = await GetRequestBodyValue();

            requestBodyValue.ToList().ForEach(r => ValidationData(templateValue, r));

            ICollection<MobileText> mobileText=new List<MobileText>();
            //mobileText.Add(await requestBodyValue.Select(async x => await GetMessageToSend(x, templateId)).ToListAsync());
            foreach (var item in requestBodyValue)
            {
                mobileText.Add(await GetMessageToSend(item, templateId));
            }

            var messageBatch = MessageBatchFactory.Create(mobileText, lineId, batchSize, "");
            var result=_messageBatchCommandService.Add(messageBatch);
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
            if (!requestBody.Keys.Contains(_Mobile))
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
            var mobileData = requestBody.Where(x => x.Key == _Mobile).FirstOrDefault().Value;
            return mobileData;
        }

        private async Task<GetTemplateDto> GetTemplateById(int templateId)
        {
            IntId id = templateId;
            var template = await _templateGetSingleHandler.Handle(id);

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

        private async Task<string> GetLineNumber(int lineId)
        {
            var line = await _lineGetSingleHandler.Handle(lineId);
            var lineNumber = line.Number;
            if (lineNumber == null)
                throw new InvalidLineException();

            return lineNumber;
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
