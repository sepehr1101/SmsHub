using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route("provider")]
    [ApiController]
    public class ProviderGetListController : BaseController
    {
        private readonly IProviderGetListHandler _getListHandler;
        public ProviderGetListController(IProviderGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetProviderDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var providers = await _getListHandler.Handle();
            return Ok(providers);
        }
    }
}
