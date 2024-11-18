using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Security.Commands.Create
{
    [Route(nameof(ServerUser))]
    [ApiController]
    public class ServerUserCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IServerUserCreateHandler _createServerUserHandler;
        public ServerUserCreateController(
            IUnitOfWork uow,
            IServerUserCreateHandler createServerUserHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createServerUserHandler = createServerUserHandler;
            _createServerUserHandler.NotNull(nameof(createServerUserHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateServerUserDto dto, CancellationToken cancellationToken)
        {
            var apiKeyAndHash= await _createServerUserHandler.Handle(dto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(apiKeyAndHash);
        }
    }
}
