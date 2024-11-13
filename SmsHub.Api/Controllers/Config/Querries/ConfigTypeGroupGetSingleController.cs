using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(ConfigTypeGroup))]
    [ApiController]
    public class ConfigTypeGroupGetSingleController : ControllerBase
    {
        private readonly IConfigTypeGroupGetSingleHandler _getSingleHandler;
        public ConfigTypeGroupGetSingleController(IConfigTypeGroupGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetConfigTypeGroupDto> GetSingle([FromBody] IntId Id)
        {
            var configTypeGroup = await _getSingleHandler.Handle(Id);
            return configTypeGroup;
        }
    }
}
