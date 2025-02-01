using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Logging.Commands.Update
{
    [Route(nameof(InformativeLog))]
    [ApiController]
    [Authorize]
    public class InformativeLogUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IInformativeLogUpdateHandler _updateCommandHandler;
        private readonly ILogLevelGetSingleHandler _logLevelGetSingleHandler;
        public InformativeLogUpdateController(
            IUnitOfWork uow,
            IInformativeLogUpdateHandler updateCommandHandler,
            ILogLevelGetSingleHandler logLevelGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _logLevelGetSingleHandler = logLevelGetSingleHandler;
            _logLevelGetSingleHandler.NotNull(nameof(logLevelGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateInformativeLogDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.InformativeLog + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateInformativeLogDto updateDto, CancellationToken cancellationToken)
        {
            var logLevel = await _logLevelGetSingleHandler.Handle(updateDto.LogLevelId);

            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}
