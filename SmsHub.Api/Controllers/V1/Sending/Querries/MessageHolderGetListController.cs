using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

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
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetMessageHolderDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList()
        {
            var messageHolders = await _getListHolder.Handle();
            return Ok(messageHolders);
        }
    }
}
