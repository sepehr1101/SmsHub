using Azure.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SmsHub.Application.Common.Base;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class SendManagerCreateHandler: ISendManagerCreateHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        private readonly ILineGetSingleHandler _lineGetSingleHandler;
        private readonly string _Mobile = "Mobile";
        public SendManagerCreateHandler(IHttpContextAccessor contextAccessor,
            ITemplateGetSingleHandler templateGetSingleHandler
            ,ILineGetSingleHandler lineGetSingleHandler)
        {
            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));

            _templateGetSingleHandler= templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));

            _lineGetSingleHandler=lineGetSingleHandler;
            _lineGetSingleHandler.NotNull(nameof(lineGetSingleHandler));
        }

        public async Task<MobileText> Handle(int templateId,int lineId, CancellationToken cancellationToken)
        {
            IntId id = templateId;

            var template = await _templateGetSingleHandler.Handle(id);
            var templateValue = DeserializeToDictionary(template.Parameters);
            if (templateValue == null)
                throw new InvalidTemplateException();

            var line = await _lineGetSingleHandler.Handle(lineId);
            var lineNumber = line.Number;
            if (lineNumber == null)
                throw new InvalidLineException();

            var requestBody = await new StreamReader(_contextAccessor.HttpContext.Request.Body).ReadToEndAsync();
            var requestBodyValue = DeserializeToDictionary(requestBody);

            ValidationData(templateValue, requestBodyValue);

            string messageToSend = CreateMessageToSend(requestBodyValue, template.Expression);

            var mobileText = new MobileText()
            {
                Text = messageToSend,
                Mobile = FindMobileUser(requestBodyValue)
            };

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

        private string CreateMessageToSend(Dictionary<string, string> data, string stringTemplate)
        {
            foreach (var item in data)
            {
               stringTemplate= stringTemplate.ReplaceCurlyBrace(item.Key, item.Value);
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
    }
}
