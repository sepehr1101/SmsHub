using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [Route(nameof(MessageDetailStatus))]
    [ApiController]
    public class MessageDetailStatusCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageDetailStatusCreateHandler _messageDetailStatusCreateHandler;
        public MessageDetailStatusCreateController(
            IUnitOfWork uow,
            IMessageDetailStatusCreateHandler messageDetailStatusCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _messageDetailStatusCreateHandler = messageDetailStatusCreateHandler;
            _messageDetailStatusCreateHandler.NotNull(nameof(messageDetailStatusCreateHandler));

        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateMessageDetailStatusDto createDto, CancellationToken cancellationToken)
        {
            await _messageDetailStatusCreateHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
