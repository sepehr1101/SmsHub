using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Update
{
    [Route(nameof(MessageDetailStatus))]
    [ApiController]
    public class MessageDetailStatusUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailStatusUpdateHandler _messageDetailStatusUpdateHandler;
        public MessageDetailStatusUpdateController(
            IUnitOfWork uow,
            IMessageDetailStatusUpdateHandler messageDetailStatusUpdateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _messageDetailStatusUpdateHandler = messageDetailStatusUpdateHandler;
            _messageDetailStatusUpdateHandler.NotNull(nameof(messageDetailStatusUpdateHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateMessageDetailStatusDto updateDto, CancellationToken cancellationToken)
        {
            await _messageDetailStatusUpdateHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }

    }
}
