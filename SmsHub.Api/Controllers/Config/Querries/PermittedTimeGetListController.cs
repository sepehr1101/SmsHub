using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(PermittedTime))]
    [ApiController]
    public class PermittedTimeGetListController : Controller
    {
        private readonly IPermittedTimeGetListHandler _getListHandler;
        public PermittedTimeGetListController(IPermittedTimeGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetPermittedTimeDto>> GetList()
        {
            var permittedTimes = await _getListHandler.Handle();
            return permittedTimes;
        }
    }
}
