using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

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
        public async Task<IActionResult> GetList()
        {
            var deepLogs = await _getListHandler.Handle();
            return Ok(deepLogs);
        }
    }
}
