using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Logging.Commands.Update
{
    [Route("LogLevel")]
    [ApiController]
    public class LogLevelUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogLevelUpdateHandler _updateCommandHandler;
        public LogLevelUpdateController(IUnitOfWork uow, ILogLevelUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateLogLevelDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
