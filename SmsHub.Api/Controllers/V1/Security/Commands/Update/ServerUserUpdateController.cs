using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Update
{
    [Route(nameof(ServerUser))]
    [ApiController]
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
        [ProducesResponseType(typeof(ApiResponseEnvelope<int>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Update([FromBody] int id)
        {
            await _updateApiKeyHandler.Handle(id);  
            return Ok(id);
        }
    }
}