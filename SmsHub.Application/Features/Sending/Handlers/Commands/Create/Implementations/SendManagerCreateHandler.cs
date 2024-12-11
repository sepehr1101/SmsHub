using Azure.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class SendManagerCreateHandler: ISendManagerCreateHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        public SendManagerCreateHandler(IHttpContextAccessor contextAccessor,ITemplateGetSingleHandler templateGetSingleHandler)
        {
            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));

            _templateGetSingleHandler= templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));
        }

        public async void Handle(int templateId, CancellationToken cancellationToken)
        {
            IntId id = templateId;

            var template = await _templateGetSingleHandler.Handle(id);
            var templateValue = DeserializeToDictionary(template.Parameters);

            var requestBody = await new StreamReader(_contextAccessor.HttpContext.Request.Body).ReadToEndAsync();
            var requestBodyValue = DeserializeToDictionary(requestBody);

            ValidationData(templateValue, requestBodyValue);

            string messageToSend = CreateMessageToSend(requestBodyValue, template.Expression);

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
                stringTemplate.ReplaceCurlyBrace(item.Key, item.Value);
            }
            return stringTemplate;
        }

        private void ValidationData(Dictionary<string, string> template, Dictionary<string, string> requestBody)
        {
            if (!requestBody.Keys.Contains("Mobile"))
                throw new InvalidDataException();

            //method + foreach
            foreach (var item in template.Keys)
            {
                if (!requestBody.ContainsKey(item))
                    throw new InvalidDataException();
            }
        }
    }
}
