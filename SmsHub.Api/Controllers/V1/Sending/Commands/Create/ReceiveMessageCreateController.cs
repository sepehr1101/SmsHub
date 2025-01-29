using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Receiving.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route(nameof(Receiving))]
    [Authorize]
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
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<Received>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum. Receive, LogLevelMessageResources.SendSection, LogLevelMessageResources.ReceiveMessage + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Receiving(int lineId, CancellationToken cancellationToken)
        {
            var result = await _receiveManagerCreateHandler.Handle(lineId);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(result);
        }

    }
}
