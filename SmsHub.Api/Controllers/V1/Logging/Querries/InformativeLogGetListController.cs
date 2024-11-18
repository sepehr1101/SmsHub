using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(InformativeLog))]
    [ApiController]
    public class InformativeLogGetListController : ControllerBase
    {
        private readonly IInformativeLogGetListHandler _getListHandler;
        public InformativeLogGetListController(IInformativeLogGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetInforamtaiveLogDto>> GetList()
        {
            var informativeLogs = await _getListHandler.Handle();
            return informativeLogs;
        }
    }
}
