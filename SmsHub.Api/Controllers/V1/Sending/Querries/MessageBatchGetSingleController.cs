using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    public class MessageBatchGetSingleController : BaseController
    {
        private readonly IMessageBatchGetSingleHandler _getSingleHandler;
        public MessageBatchGetSingleController(IMessageBatchGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var messageBatch = await _getSingleHandler.Handle(Id);
            return Ok(messageBatch);
        }
    }
}
