using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Consumer.Querries
{
    [Route(nameof(ConsumerSafeIp))]
    [ApiController]
    public class ConsumerSafeIpGetSingleController : ControllerBase
    {
        private readonly IConsumerSafeIpGetSingleHandler _getSingleHandler;
        public ConsumerSafeIpGetSingleController(IConsumerSafeIpGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetConsumerSafaIpDto> GetSingle([FromBody] IntId Id)
        {
            var consumerSafeIp = await _getSingleHandler.Handle(Id);
            return consumerSafeIp;
        }

    }
}
