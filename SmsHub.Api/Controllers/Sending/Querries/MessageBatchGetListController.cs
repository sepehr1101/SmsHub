using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    public class MessageBatchGetListController : ControllerBase
    {
        private readonly IMessageBatchGetListHandler _getListHandler;
        public MessageBatchGetListController(IMessageBatchGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetMessageBatchDto>> GetList()
        {
            var messageBatchs = await _getListHandler.Handle();
            return messageBatchs;
        }
    }
}
