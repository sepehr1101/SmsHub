using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(ConsumerSafeIp))]
    [ApiController]
    public class ConsumerSafeIpGetSingleController : BaseController
    {
        private readonly IConsumerSafeIpGetSingleHandler _getSingleHandler;
        public ConsumerSafeIpGetSingleController(IConsumerSafeIpGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetConsumerSafaIpDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var consumerSafeIp = await _getSingleHandler.Handle(Id);
            return Ok(consumerSafeIp);
        }

    }
}
