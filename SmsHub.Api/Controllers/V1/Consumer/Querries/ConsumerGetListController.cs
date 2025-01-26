using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(Consumer))]
    [ApiController]
    public class ConsumerGetListController : BaseController
    {
        private readonly IConsumerGetListHandler _getListHandler;
        public ConsumerGetListController(IConsumerGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetConsumerDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var consumers = await _getListHandler.Handle();
            return Ok(consumers);
        }
    }
}
