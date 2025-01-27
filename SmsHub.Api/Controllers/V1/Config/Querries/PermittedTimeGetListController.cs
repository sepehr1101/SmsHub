using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route("permitted-time")]
    [ApiController]
    public class PermittedTimeGetListController : BaseController
    {
        private readonly IPermittedTimeGetListHandler _getListHandler;
        public PermittedTimeGetListController(IPermittedTimeGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetPermittedTimeDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var permittedTimes = await _getListHandler.Handle();
            return Ok(permittedTimes);
        }
    }
}
