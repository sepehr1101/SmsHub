using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(ConsumerSafeIp))]
    [ApiController]
    public class ConsumerSafeIpGetListController : BaseController
    {
        private readonly IConsumerSafeIpGetListHandler _getListHandler;
        public ConsumerSafeIpGetListController(IConsumerSafeIpGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetConsumerSafaIpDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var consumerSafeIps = await _getListHandler.Handle();
            return Ok(consumerSafeIps);
        }
    }
}
