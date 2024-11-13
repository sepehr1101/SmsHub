using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    [Route(nameof(MessagesDetail))]
    [ApiController]
    public class MessageDetailGetSingleController : ControllerBase
    {
        private readonly IMessageDetailGetSingleHandler _getSingleHandler;
        public MessageDetailGetSingleController(IMessageDetailGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetMessageDetailDto> GetSingle([FromBody] IntId Id)
        {
            var messageDetail = await _getSingleHandler.Handle(Id);
            return messageDetail;
        }
    }
}
