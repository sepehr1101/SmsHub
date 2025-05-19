using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    [Authorize]
    public class MessageBatchCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageBatchCreateHandler _createCommandHandler;
        private readonly ILineGetSingleHandler _lineGetSingleHandler;
        public MessageBatchCreateController(
            IUnitOfWork uow,
            IMessageBatchCreateHandler createCommandHandler,
            ILineGetSingleHandler lineGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _lineGetSingleHandler=lineGetSingleHandler;
            _lineGetSingleHandler.NotNull(nameof(lineGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateMessageBatchDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageBatch + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateMessageBatchDto createDto, CancellationToken cancellationToken)
        {
            var line = await _lineGetSingleHandler.Handle(createDto.LineId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}