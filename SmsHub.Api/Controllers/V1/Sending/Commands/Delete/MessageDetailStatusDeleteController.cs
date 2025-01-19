using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Delete
{
    [Route(nameof(MessageDetailStatus))]
    [ApiController]
    public class MessageDetailStatusDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailStatusDeleteHandler _messageDetailStatusDeleteHandler;
        public MessageDetailStatusDeleteController(
            IUnitOfWork uow,
            IMessageDetailStatusDeleteHandler messageDetailStatusDeleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _messageDetailStatusDeleteHandler = messageDetailStatusDeleteHandler;
            _messageDetailStatusDeleteHandler.NotNull(nameof(messageDetailStatusDeleteHandler));

        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] DeleteMessageDetailStatusDto deleteDto, CancellationToken cancellationToken)
        {
            await _messageDetailStatusDeleteHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }

    }
}
