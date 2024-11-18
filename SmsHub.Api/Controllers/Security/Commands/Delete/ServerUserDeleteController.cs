using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Security.Commands.Delete
{
    [Route(nameof(ServerUser))]
    [ApiController]
    public class ServerUserDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IServerUserDeleteHandler _deleteHandler;
        public ServerUserDeleteController(IUnitOfWork uow, IServerUserDeleteHandler deleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteHandler = deleteHandler;
            _deleteHandler.NotNull(nameof(deleteHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteServerUserDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }

    }
}
