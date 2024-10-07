using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Sending.Commands.Create
{
    [Route("api/MessageBatch")]
    [ApiController]
    public class MessageBatchCreateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICreateMessageBatchCommandHandler _createCommandHandler;
        public MessageBatchCreateController(IUnitOfWork uow, ICreateMessageBatchCommandHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull( nameof(createCommandHandler));   
        }
        [HttpGet(Name = nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateMessageBatchDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }
    }
}