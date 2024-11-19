using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    public class MessageBatchGetListController : BaseController
    {
        private readonly IMessageBatchGetListHandler _getListHandler;
        public MessageBatchGetListController(IMessageBatchGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var messageBatchs = await _getListHandler.Handle();
            return Ok(messageBatchs);
        }
    }
}
