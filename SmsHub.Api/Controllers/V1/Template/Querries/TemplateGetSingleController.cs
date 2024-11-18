using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route(nameof(Template))]
    [ApiController]
    public class TemplateGetSingleController : BaseController
    {
        private readonly ITemplateGetSingleHandler _getSingleHandler;
        public TemplateGetSingleController(ITemplateGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetTemplateDto> GetSingle([FromBody] IntId Id)
        {
            var template = await _getSingleHandler.Handle(Id);
            return template;
        }
    }
}
