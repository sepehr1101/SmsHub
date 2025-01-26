using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Create
{
    [Route(nameof(Config))]
    [ApiController]
    public class ConfigCreateController : BaseController
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
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateConfigDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateConfigDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
