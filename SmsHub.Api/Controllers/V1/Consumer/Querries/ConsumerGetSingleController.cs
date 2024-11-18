using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(Consumer))]
    [ApiController]
    public class ConsumerGetSingleController : BaseController
    {
        private readonly IConsumerGetSingleHandler _getSingleHandler;
        public ConsumerGetSingleController(IConsumerGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetConsumerDto> GetSingle([FromBody] IntId Id)
        {
            var consumers = await _getSingleHandler.Handle(Id);
            return consumers;
        }
    }
}
