using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Security.Commands.Update
{
    [Route("api/ServerUser")]
    [ApiController]
    public class ServerUserUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IServerUserApiKeyRenewalHandler _updateApiKeyHandler;
        public ServerUserUpdateController(IUnitOfWork uow,IServerUserApiKeyRenewalHandler updateApiKeyHandler)
        {
            _uow=uow;
            _uow.NotNull(nameof(uow));

            _updateApiKeyHandler=updateApiKeyHandler;
            _updateApiKeyHandler.NotNull(nameof(updateApiKeyHandler));
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] int id)
        {
            await _updateApiKeyHandler.Handle(id);  
            return Ok();
        }
    }
}
