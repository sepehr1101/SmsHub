using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Sending.Commands.Update
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    public class MessageBatchUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageBatchUpdateHandler _updateCommandHandler;
        public MessageBatchUpdateController(IUnitOfWork uow, IMessageBatchUpdateHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateMessageBatchDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
