using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(ConsumerLine))]
    [ApiController]
    public class ConsumerLineGetSingleController : ControllerBase
    {
        private readonly IConsumerLineGetSingleHandler _getSingleHandler;
        public ConsumerLineGetSingleController(IConsumerLineGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetConsumerLineDto> GetSingle([FromBody] IntId Id)
        {
            var consumerLine = await _getSingleHandler.Handle(Id);
            return consumerLine;
        }
    }
}
