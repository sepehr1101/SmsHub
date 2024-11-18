using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Logging.Commands.Create
{
    [Route(nameof(DeepLog))]
    [ApiController]
    public class DeepLogCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IDeepLogCreateHandler _createCommandHandler;
        public DeepLogCreateController(IUnitOfWork uow, IDeepLogCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));
            
            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateDeepLogDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
