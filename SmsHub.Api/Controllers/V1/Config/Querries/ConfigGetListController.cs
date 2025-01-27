using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route("config")]
    [ApiController]
    public class ConfigGetListController : BaseController
    {
        private readonly IConfigGetListHandler _getListHandler;
        public ConfigGetListController(IConfigGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetConfigDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var configs = await _getListHandler.Handle();
            return Ok(configs);
        }

    }
}
