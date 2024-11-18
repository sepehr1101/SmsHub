using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Config.Commands.Create
{
    [Route(nameof(Config))]
    [ApiController]
    public class ConfigCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfigCreateHandler _createCommandHandler;
        public ConfigCreateController(
            IUnitOfWork uow, 
            IConfigCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateConfigDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
