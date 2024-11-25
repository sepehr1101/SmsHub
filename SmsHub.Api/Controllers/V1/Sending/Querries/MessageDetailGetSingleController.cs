using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessagesDetail))]
    [ApiController]
    public class MessageDetailGetSingleController : BaseController
    {
        private readonly IMessageDetailGetSingleHandler _getSingleHandler;
        public MessageDetailGetSingleController(IMessageDetailGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] LongId Id)
        {
            var messageDetail = await _getSingleHandler.Handle(Id);
            return Ok(messageDetail);
        }
    }
}
