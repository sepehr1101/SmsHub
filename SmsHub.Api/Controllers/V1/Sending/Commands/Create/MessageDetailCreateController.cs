using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
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
    [Route(nameof(MessageDetail))]
    [ApiController]
    [Authorize]
    public class MessageDetailCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailCreateHandler _createCommandHandler;
        private readonly IMessageHolderGetSingleHandler _messagesHolderGetSingleHandler;
        public MessageDetailCreateController(
            IUnitOfWork uow, 
            IMessageDetailCreateHandler createCommandHandler,
            IMessageHolderGetSingleHandler messagesHolderGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));

            _messagesHolderGetSingleHandler= messagesHolderGetSingleHandler;
            _messagesHolderGetSingleHandler.NotNull(nameof(messagesHolderGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateMessageDetailDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageDetail + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateMessageDetailDto createDto, CancellationToken cancellationToken)
        {
            var messagesHolder = await _messagesHolderGetSingleHandler.Handle(createDto.MessagesHolderId);

            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
