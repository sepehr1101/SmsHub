using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Receiving.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route(nameof(Receiving))]
    public class ReceiveMessageCreateController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IReceiveManagerCreateHandler _receiveManagerCreateHandler;
        private readonly IReceiveCommandService _receiveCommandService;
        private readonly IProviderResponseStatusQueryService _responseStatusQueryService;

        public ReceiveMessageCreateController(
            IUnitOfWork uow,
            IReceiveManagerCreateHandler receiveManagerCreateHandler,
            IReceiveCommandService receiveCommandService,
            IProviderResponseStatusQueryService responseStatusQueryService)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _receiveManagerCreateHandler = receiveManagerCreateHandler;
            _receiveManagerCreateHandler.NotNull(nameof(receiveManagerCreateHandler));

            _receiveCommandService = receiveCommandService;
            _receiveCommandService.NotNull(nameof(receiveCommandService));

            _responseStatusQueryService = responseStatusQueryService;
            _responseStatusQueryService.NotNull(nameof(responseStatusQueryService));
        }

        [HttpGet]
        [Route("Receiving/{lineId}")]
        public async Task<IActionResult> Receiving(int lineId, CancellationToken cancellationToken)
        {
            var result = await _receiveManagerCreateHandler.Handle(lineId);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }

    }
}
