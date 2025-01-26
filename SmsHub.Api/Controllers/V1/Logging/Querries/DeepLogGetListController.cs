using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(DeepLog))]
    [ApiController]
    public class DeepLogGetListController : BaseController
    {
        private readonly IDeepLogGetListHandler _getListHandler;
        public DeepLogGetListController(IDeepLogGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetDeepLogDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var deepLogs = await _getListHandler.Handle();
            return Ok(deepLogs);
        }
    }
}
