using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(ConfigTypeGroup))]
    [ApiController]
    public class ConfigTypeGroupGetListController : BaseController
    {
        private readonly IConfigTypeGroupGetListHandler _getListHandler;
        public ConfigTypeGroupGetListController(IConfigTypeGroupGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var configTypeGroups = await _getListHandler.Handle();
            return Ok(configTypeGroups);
        }
    }
}
