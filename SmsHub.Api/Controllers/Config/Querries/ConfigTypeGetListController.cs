using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(ConfigType))]
    [ApiController]
    public class ConfigTypeGetListController : ControllerBase
    {
        private readonly IConfigTypeGetListHandler _getListHandler;
        public ConfigTypeGetListController(IConfigTypeGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetConfigTypeDto>> GetList()
        {
            var ConfigTypes = await _getListHandler.Handle();
            return ConfigTypes;
        }
    }
}
