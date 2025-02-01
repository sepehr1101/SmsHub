using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Queries.Implementations;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
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
        private readonly ILogLevelGetSingleHandler _logLevelGetSingleHandler;
        public InformativeLogCreateController(
            IUnitOfWork uow,
        IInformativeLogCreateHandler createCommandHandler,
            ILogLevelGetSingleHandler logLevelGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _logLevelGetSingleHandler = logLevelGetSingleHandler; 
            _logLevelGetSingleHandler.NotNull(nameof(logLevelGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateInformativeLogDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.InformativeLog + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateInformativeLogDto createDto, CancellationToken cancellationToken)
        {
            var logLevel = await _logLevelGetSingleHandler.Handle(createDto.LogLevelId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
