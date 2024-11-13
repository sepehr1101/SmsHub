using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Config.Querries
{
    [Route(nameof(Config))]
    [ApiController]
    public class ConfigGetSingleController : ControllerBase
    {
        private readonly IConfigGetSingleHandler _getSingleHandler;
        public ConfigGetSingleController(IConfigGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetConfigDto> GetSingle([FromBody] IntId Id)
        {
            var config = await _getSingleHandler.Handle(Id);
            return config;
        }
    }
}
