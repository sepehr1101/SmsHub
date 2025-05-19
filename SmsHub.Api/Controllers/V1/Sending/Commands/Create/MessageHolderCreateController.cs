using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [Route(nameof(MessagesHolder))]
    [ApiController]
    [Authorize]
    public class MessageHolderCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageHolderCreateHandler _createCommandHandler;
        private readonly IMessageBatchGetSingleHandler _messageBatchSingleHandler;
        public MessageHolderCreateController(
            IUnitOfWork uow,
            IMessageHolderCreateHandler createCommandHandler,
            IMessageBatchGetSingleHandler messageBatchSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _messageBatchSingleHandler = messageBatchSingleHandler;
            _messageBatchSingleHandler.NotNull(nameof(messageBatchSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateMessagesHolderDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageHolder + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateMessagesHolderDto createDto, CancellationToken cancellationToken)
        {
            var messagebatch = await _messageBatchSingleHandler.Handle(createDto.MessageBatchId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
