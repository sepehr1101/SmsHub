using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Implementations;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Update
{
    [Route(nameof(MessageDetail))]
    [ApiController]
    [Authorize]
    public class MessageDetailUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailUpdateHandler _updateCommandHandler;
        private readonly IMessageHolderGetSingleHandler _messagesHolderGetSingleHandler;

        public MessageDetailUpdateController(
            IUnitOfWork uow,
            IMessageDetailUpdateHandler updateCommandHandler,
            IMessageHolderGetSingleHandler messagesHolderGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _messagesHolderGetSingleHandler = messagesHolderGetSingleHandler;
            _messagesHolderGetSingleHandler.NotNull(nameof(messagesHolderGetSingleHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateMessageDetailDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageDetail + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateMessageDetailDto updateDto, CancellationToken cancellationToken)
        {
            var messagesHolder = await _messagesHolderGetSingleHandler.Handle(updateDto.MessagesHolderId);

            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}
