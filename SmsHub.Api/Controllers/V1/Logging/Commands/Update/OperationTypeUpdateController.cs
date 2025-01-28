using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Logging.Commands.Update
{
    [Route(nameof(OperationType))]
    [ApiController]
    [Authorize]
    public class OperationTypeUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IOperationTypeUpdateHandler _updateCommandHandler;
        public OperationTypeUpdateController(
            IUnitOfWork uow, 
            IOperationTypeUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateOperationTypeDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.OpetationType + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateOperationTypeDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
           return Ok(updateDto);
        }
    }
}
