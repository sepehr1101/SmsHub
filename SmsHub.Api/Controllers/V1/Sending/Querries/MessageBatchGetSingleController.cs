using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

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
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetMessageBatchDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var messageBatch = await _getSingleHandler.Handle(Id);
            return Ok(messageBatch);
        }
    }
}
