using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.Sending.Querries
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    public class MessageBatchGetSingleController : ControllerBase
    {
        private readonly IMessageBatchGetSingleHandler _getSingleHandler;
        public MessageBatchGetSingleController(IMessageBatchGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetMessageBatchDto> GetSingle([FromBody] IntId Id)
        {
            var messageBatch = await _getSingleHandler.Handle(Id);
            return messageBatch;
        }
    }
}
