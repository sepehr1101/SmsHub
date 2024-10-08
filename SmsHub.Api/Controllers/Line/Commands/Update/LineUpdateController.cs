using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Line.Commands.Update
{
    [Route("api/Line")]
    [ApiController]
    public class LineUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILineUpdateHandler _updateCommandHandler;
        public LineUpdateController(IUnitOfWork uow, ILineUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateLineDto deleteDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
