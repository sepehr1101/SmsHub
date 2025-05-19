using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Logging.Commands.Create
{
    [Route(nameof(DeepLog))]
    [ApiController]
    [Authorize]
    public class DeepLogCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IDeepLogCreateHandler _createCommandHandler;
        private readonly IOperationTypeGetSingleHandler _operationTypeGetSingleHandler;
        public DeepLogCreateController(
            IUnitOfWork uow,
            IDeepLogCreateHandler createCommandHandler,
            IOperationTypeGetSingleHandler operationTypeGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _operationTypeGetSingleHandler= operationTypeGetSingleHandler;
            _operationTypeGetSingleHandler.NotNull(nameof(operationTypeGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateDeepLogDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.DeepLog + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateDeepLogDto createDto, CancellationToken cancellationToken)
        {
            IntId operationTypeId=createDto.OperationTypeId;
            var operationType = await _operationTypeGetSingleHandler.Handle(operationTypeId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
