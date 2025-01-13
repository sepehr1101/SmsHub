using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Receiving.Commands.Create
{
    [Route(nameof(Receiving))]
    [ApiController]
    public class CreateReceiveMessageController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IReceiveManagerCreateHandler _receiveManagerCreateHandler;
        public CreateReceiveMessageController(
            IUnitOfWork uow,
            IReceiveManagerCreateHandler receiveManagerCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _receiveManagerCreateHandler = receiveManagerCreateHandler;
            _receiveManagerCreateHandler.NotNull(nameof(receiveManagerCreateHandler));
        }

        [HttpPost]
        [Route("Receiving/{lineId}")]
        public async Task<IActionResult> Receiving(int lineId)
        {
            await _receiveManagerCreateHandler.Handle(lineId);
            return Ok();
        }
    }
}
