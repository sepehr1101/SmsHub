using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.Consumer.Querries
{
    [Route(nameof(ConsumerSafeIp))]
    [ApiController]
    public class ConsumerSafeIpGetListController : Controller
    {
        private readonly IConsumerSafeIpGetListHandler _getListHandler;
        public ConsumerSafeIpGetListController(IConsumerSafeIpGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetConsumerSafaIpDto>> GetList()
        {
            var consumerSafeIps = await _getListHandler.Handle();
            return consumerSafeIps;
        }
    }
}
