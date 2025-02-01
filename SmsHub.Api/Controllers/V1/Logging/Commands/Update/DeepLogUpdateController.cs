using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Logging.Commands.Update
{
    [Route(nameof(DeepLog))]
    [ApiController]
    [Authorize]
    public class DeepLogUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IDeepLogUpdateHandler _updateCommandHandler;
        private readonly IOperationTypeGetSingleHandler _operationTypeGetSingleHandler;
        public DeepLogUpdateController(
            IUnitOfWork uow,
            IDeepLogUpdateHandler updateCommandHandler,
            IOperationTypeGetSingleHandler operationTypeGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _operationTypeGetSingleHandler = operationTypeGetSingleHandler;
            _operationTypeGetSingleHandler.NotNull(nameof(operationTypeGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateDeepLogDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.DeepLog + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateDeepLogDto updateDto, CancellationToken cancellationToken)
        {
            IntId operationTypeId = updateDto.OperationTypeId;
            var operationType = await _operationTypeGetSingleHandler.Handle(operationTypeId);

            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}
