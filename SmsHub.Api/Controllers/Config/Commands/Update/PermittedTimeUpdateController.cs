using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Config.Commands.Update
{
    [Route("api/PermittedTime")]
    [ApiController]
    public class PermittedTimeUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IUpdatePermittedTimeHandler _updateCommandHandler;
        public PermittedTimeUpdateController(IUnitOfWork uow, IUpdatePermittedTimeHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));    
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdatePermittedTimeDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto,cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
