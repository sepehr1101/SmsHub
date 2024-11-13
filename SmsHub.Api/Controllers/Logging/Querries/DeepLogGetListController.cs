using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Logging.Querries
{
    [Route(nameof(DeepLog))]
    [ApiController]
    public class DeepLogGetListController : ControllerBase
    {
        private readonly IDeepLogGetListHandler _getListHandler;
        public DeepLogGetListController(IDeepLogGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetDeepLogDto>> GetList()
        {
            var deepLogs = await _getListHandler.Handle();
            return deepLogs;
        }
    }
}
