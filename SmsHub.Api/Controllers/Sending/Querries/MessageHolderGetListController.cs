using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    [Route(nameof(MessagesHolder))]
    [ApiController]
    public class MessageHolderGetListController : ControllerBase
    {
        private readonly IMessageHolderGetListHandler _getListHolder;
        public MessageHolderGetListController(IMessageHolderGetListHandler getListHolder)
        {
            _getListHolder = getListHolder;
            _getListHolder.NotNull(nameof(getListHolder));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetMessageHolderDto>> GetList()
        {
            var messageHolders = await _getListHolder.Handle();
            return messageHolders;
        }
    }
}
