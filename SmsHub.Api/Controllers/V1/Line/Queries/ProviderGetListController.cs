using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Line.Queries
{
    [Route(nameof(Provider))]
    [ApiController]
    public class ProviderGetListController : ControllerBase
    {
        private readonly IProviderGetListHandler _getListHandler;
        public ProviderGetListController(IProviderGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetProviderDto>> GetList()
        {
            var providers = await _getListHandler.Handle();
            return providers;
        }
    }
}
