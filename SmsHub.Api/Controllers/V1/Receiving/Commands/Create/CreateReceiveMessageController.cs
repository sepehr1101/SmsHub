using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Receiving.Commands.Create
{
    [ApiController]
    [Route(nameof(Receiving))]
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

        [HttpGet]
        [Route("Receiving/{lineId}")]
        public async Task<IActionResult> Receiving(int lineId,CancellationToken cancellationToken)
        {
          var result=  await _receiveManagerCreateHandler.Handle(lineId);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
