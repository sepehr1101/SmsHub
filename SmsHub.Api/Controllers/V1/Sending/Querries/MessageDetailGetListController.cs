using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessagesDetail))]
    [ApiController]
    public class MessageDetailGetListController : ControllerBase
    {
        private readonly IMessageDetailGetListHandler _getListHandler;
        public MessageDetailGetListController(IMessageDetailGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetMessageDetailDto>> GetList()
        {
            var messageDetails = await _getListHandler.Handle();
            return messageDetails;
        }
    }
}
