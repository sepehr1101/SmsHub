using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(ConfigType))]
    [ApiController]

    public class ConfigTypeGetSingleController : ControllerBase
    {
        private readonly IConfigTypeGetSingleHandler _getSingleHandler;
        public ConfigTypeGetSingleController(IConfigTypeGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetConfigTypeDto> GetSingle([FromBody] ShortId Id)
        {
            var configType = await _getSingleHandler.Handle(Id);
            return configType;
        }
    }
}
