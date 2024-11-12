using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Consumer.Querries
{
    [Route(nameof(ConsumerLine))]
    [ApiController]
    public class ConsumerLineGetListController : Controller
    {
        private readonly IConsumerLineGetListHandler _getListHandler;
        public ConsumerLineGetListController(IConsumerLineGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetConsumerLineDto>> GetList()
        {
            var consumerLines = await _getListHandler.Handle();
            return consumerLines;
        }
    }
}
