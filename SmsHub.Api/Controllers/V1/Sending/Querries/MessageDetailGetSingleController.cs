using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageDetail))]
    [ApiController]
    [Authorize]
    public class MessageDetailGetSingleController : BaseController
    {
        private readonly IMessageDetailGetSingleHandler _getSingleHandler;
        private readonly IUnitOfWork _uow;
        public MessageDetailGetSingleController(IMessageDetailGetSingleHandler getSingleHandler,
            IUnitOfWork uow)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetMessageBatchDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageDetail + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetSingle([FromBody] LongId Id, CancellationToken cancellationToken)
        {
            var messageDetail = await _getSingleHandler.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messageDetail);
        }
    }
}
