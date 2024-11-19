using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessagesHolder))]
    [ApiController]
    public class MessageHolderGetListController : BaseController
    {
        private readonly IMessageHolderGetListHandler _getListHolder;
        public MessageHolderGetListController(IMessageHolderGetListHandler getListHolder)
        {
            _getListHolder = getListHolder;
            _getListHolder.NotNull(nameof(getListHolder));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var messageHolders = await _getListHolder.Handle();
            return Ok(messageHolders);
        }
    }
}
