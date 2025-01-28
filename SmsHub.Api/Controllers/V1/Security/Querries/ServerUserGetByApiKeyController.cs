using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Security.Querries
{
    [Route(nameof(ServerUser))]
    [ApiController]
    [Authorize]
    public class ServerUserGetByApiKeyController : BaseController
    {
        private readonly IServerUserGetByApiKeyHandler _getByApiKeyHandler;
        private readonly IUnitOfWork _uow;
        public ServerUserGetByApiKeyController(
            IServerUserGetByApiKeyHandler getByApiKeyHandler,
            IUnitOfWork uow)
        {
            _getByApiKeyHandler = getByApiKeyHandler;
            _getByApiKeyHandler.NotNull(nameof(getByApiKeyHandler));

            _uow = uow;
            _uow.NotNull(nameof(_uow));
        }

        [HttpPost]
        [Route(nameof(GetByApiKey))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetServerUserDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.ServerUser + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetByApiKey([FromBody] StringId apiKey, CancellationToken cancellationToken)
        {
            var serverUser = await _getByApiKeyHandler.Handle(apiKey);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(serverUser);
        }
    }
}
