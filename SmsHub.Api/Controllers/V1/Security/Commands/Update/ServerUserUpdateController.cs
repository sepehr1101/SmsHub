using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Update
{
    [Route(nameof(ServerUser))]
    [ApiController]
    [Authorize]
    public class ServerUserUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IServerUserApiKeyRenewalHandler _updateApiKeyHandler;
        public ServerUserUpdateController(
            IUnitOfWork uow, 
            IServerUserApiKeyRenewalHandler updateApiKeyHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateApiKeyHandler = updateApiKeyHandler;
            _updateApiKeyHandler.NotNull(nameof(updateApiKeyHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<IntId>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.ServerUser + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] int id,CancellationToken cancellationToken)
        {
            await _updateApiKeyHandler.Handle(id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(new IntId(id));
        }
    }
}