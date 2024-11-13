using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Security.Querries
{
    [Route(nameof(Security))]
    [ApiController]
    public class ServerUserGetByApiKeyController : ControllerBase
    {
        private readonly IServerUserGetByApiKeyHandler _getByApiKeyHandler;
        public ServerUserGetByApiKeyController(IServerUserGetByApiKeyHandler getByApiKeyHandler)
        {
             _getByApiKeyHandler = getByApiKeyHandler;
            _getByApiKeyHandler.NotNull(nameof(getByApiKeyHandler));
        }

        [HttpPost]
        [Route(nameof(GetByApiKey))]
        public async Task<GetServerUserDto> GetByApiKey([FromBody] StringId apiKey)
        {
            var serverUser = await _getByApiKeyHandler.Handle(apiKey);
            return serverUser;
        }
    }
}
