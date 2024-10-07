using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Config.Commands.Create
{
    [Route("api/ConfigTypeGroup")]
    [ApiController]
    public class ConfigTypeGroupCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICreateConfigTypeGroupCommandHandler _createCommandHandler;
        public ConfigTypeGroupCreateController(
            IUnitOfWork uow, 
            ICreateConfigTypeGroupCommandHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }
        [HttpGet(Name = nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateConfigTypeGroupDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
