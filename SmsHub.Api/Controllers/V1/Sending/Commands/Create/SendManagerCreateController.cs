using Aban360.Api.Controllers.V1;
using HandlebarsDotNet;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Index.HPRtree;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
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

            Dictionary<string, string> templateProp = new Dictionary<string, string>();
            var templateValue=JsonConvert.DeserializeObject<Dictionary<string, string>>(template.Parameters);

            var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
            var requestBodyValue=JsonConvert.DeserializeObject<Dictionary<string,string>>(requestBody);
            
            if (!requestBodyValue.Keys.Contains("Mobile"))
                throw new InvalidDataException();

            foreach (var item in templateValue.Keys)
            {
                if (!requestBodyValue.ContainsKey(item))
                    throw new InvalidDataException();
            }

            foreach (var item in requestBodyValue)
            {
                template.Expression.Replace("{" + item.Key + "}", item.Value);
            }

            string message = template.Expression;

            return Ok(Id);
        }
    }
}
