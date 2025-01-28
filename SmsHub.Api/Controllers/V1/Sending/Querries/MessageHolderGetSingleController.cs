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
    [Route(nameof(MessagesHolder))]
    [ApiController]
    [Authorize]
    public class MessageHolderGetSingleController : BaseController
    {
        private readonly IMessageHolderGetSingleHandler _getSingleHolder;
        private readonly IUnitOfWork _uow;
        public MessageHolderGetSingleController(IMessageHolderGetSingleHandler getSingleHolder,
            IUnitOfWork uow)
        {
            _getSingleHolder = getSingleHolder;
            _getSingleHolder.NotNull(nameof(getSingleHolder));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetMessageHolderDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageHolder + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetSingle([FromBody] GuidId Id, CancellationToken cancellationToken)
        {
            var messageHolder = await _getSingleHolder.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messageHolder);
        }
    }
}
