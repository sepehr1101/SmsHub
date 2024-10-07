using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.Consumer.Commands.Update
{
    [Route("api/ConsumerSafeIp")]
    [ApiController]
    public class ConsumerSafeIpUpdateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IUpdateConsumerSafaIpHandler _updateCommandHandler;
        public ConsumerSafeIpUpdateController(IUnitOfWork uow, IUpdateConsumerSafaIpHandler updateCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));
        }
        [HttpGet(Name = nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateConsumerSafeIpDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
