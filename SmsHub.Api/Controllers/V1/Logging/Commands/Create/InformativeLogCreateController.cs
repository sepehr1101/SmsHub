using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Logging.Commands.Create
{
    [Route(nameof(InformativeLog))]
    [ApiController]
    [Authorize]
    public class InformativeLogCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IInformativeLogCreateHandler _createCommandHandler;
        public InformativeLogCreateController(
            IUnitOfWork uow, 
            IInformativeLogCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateInformativeLogDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.InformativeLog + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateInformativeLogDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
