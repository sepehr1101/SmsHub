using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Create
{
    [Route("provider")]
    [ApiController]
    public class ProviderCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IProviderCreateHandler _createCommandHandler;
        public ProviderCreateController(
            IUnitOfWork uow,
            IProviderCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(_createCommandHandler));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateProviderDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateProviderDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);       
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
