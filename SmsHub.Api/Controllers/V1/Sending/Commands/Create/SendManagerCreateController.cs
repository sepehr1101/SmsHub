using Aban360.Api.Controllers.V1;
using HandlebarsDotNet;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Index.HPRtree;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Dynamic;
using System.Text;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route("Send")]
    public class SendManagerCreateController : BaseController
    {
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        private readonly IUnitOfWork _uow;
        public SendManagerCreateController(ITemplateGetSingleHandler templateGetSingleHandler,
            IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _templateGetSingleHandler = templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));
        }


        [HttpPost]
        [Route("SendManager/{templateId}")]
        public async Task<IActionResult> SendManager(int templateId)
        {
            var Id = new IntId()
            {
                Id = templateId
            };
            var template = await _templateGetSingleHandler.Handle(Id);
            var templateValue = DeserializeToDictionary(template.Parameters);
            
            var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
            var requestBodyValue = DeserializeToDictionary(requestBody);

            ValidationData(templateValue, requestBodyValue);
          
            string messageToSend = CreateMessageToSend(requestBodyValue, template.Expression);

            return Ok(messageToSend);
        }

        [NonAction]
        public Dictionary<string, string> DeserializeToDictionary(string data)
        {
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            return result;
        }

        [NonAction]
        public string CreateMessageToSend(Dictionary<string, string> data,string stringTemplate)
        {
            foreach (var item in data)
            {
                stringTemplate = stringTemplate.Replace("{" + item.Key + "}", item.Value);
                //if (stringTemplate.Contains(item.Key))
                //{
                //  stringTemplate=  stringTemplate.Replace("{" + item.Key + "}", item.Value);
                //}
            }
            return stringTemplate;
        }

        [NonAction]
        public async void ValidationData(Dictionary<string, string> template, Dictionary<string, string> requestBody)
        {
            if (!requestBody.Keys.Contains("Mobile"))
                throw new InvalidDataException();

            foreach (var item in template.Keys)
            {
                if (!requestBody.ContainsKey(item))
                    throw new InvalidDataException();
            }
        }
    }
}
