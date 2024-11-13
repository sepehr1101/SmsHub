using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(Config))]
    [ApiController]
    public class ConfigGetListController : ControllerBase
    {
        private readonly IConfigGetListHandler _getListHandler;
        public ConfigGetListController(IConfigGetListHandler getListHandler)
        {
            _getListHandler=getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetConfigDto>> GetList()
        {
            var configs = await _getListHandler.Handle();
            return configs;
        }
        
    }
}
