using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Security.Commands.Create
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerUserCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICreateServerUserHandler _createServerUserHandler;
        public ServerUserCreateController(
            IUnitOfWork uow,
            ICreateServerUserHandler createServerUserHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createServerUserHandler = createServerUserHandler;
            _createServerUserHandler.NotNull(nameof(createServerUserHandler));
        }

        [HttpPost(Name ="CreateServerUser")]
        public async Task<IActionResult> Create([FromBody] CreateServerUserDto dto, CancellationToken cancellationToken)
        {
            var apiKeyAndHash= await _createServerUserHandler.Handle(dto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(apiKeyAndHash.ApiKey);
        }
    }
}
