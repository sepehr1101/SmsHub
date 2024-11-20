using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Consumer.Querries
{
    [Route(nameof(ConsumerLine))]
    [ApiController]
    public class ConsumerLineGetListController : BaseController
    {
        private readonly IConsumerLineGetListHandler _getListHandler;
        public ConsumerLineGetListController(IConsumerLineGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var consumerLines = await _getListHandler.Handle();
            return Ok(consumerLines);
        }
    }
}
