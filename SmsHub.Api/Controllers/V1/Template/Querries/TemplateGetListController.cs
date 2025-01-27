using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Template.Querries
{
    [Route("template")]
    [ApiController]
    public class TemplateGetListController : BaseController
    {
        private readonly ITemplateGetListHandler _getListHandler;
        public TemplateGetListController(ITemplateGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetTemplateDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var Templates = await _getListHandler.Handle();
            return Ok(Templates);
        }
    }
}
