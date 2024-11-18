using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageState))]
    [ApiController]
    public class MessageStateGetListController : ControllerBase
    {
        private readonly IMessageStateGetListHandler _getListHandler;
        public MessageStateGetListController(IMessageStateGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetMessageStateDto>> GetList()
        {
            var messageStates = await _getListHandler.Handle();
            return messageStates;
        }
    }
}
