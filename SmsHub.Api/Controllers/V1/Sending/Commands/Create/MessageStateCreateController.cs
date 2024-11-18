using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [Route(nameof(MessageState))]
    [ApiController]
    public class MessageStateCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageStateCreateHandler _createCommandHandler;
        public MessageStateCreateController(IUnitOfWork uow, IMessageStateCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateMessageStateDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}
