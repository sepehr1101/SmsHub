using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessagesHolder))]
    [ApiController]
    [Authorize]
    public class MessageHolderGetListController : BaseController
    {
        private readonly IMessageHolderGetListHandler _getListHolder;
        private readonly IUnitOfWork _uow;
        public MessageHolderGetListController(IMessageHolderGetListHandler getListHolder,
            IUnitOfWork uow)
        {
            _getListHolder = getListHolder;
            _getListHolder.NotNull(nameof(getListHolder));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetMessageHolderDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageHolder + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var messageHolders = await _getListHolder.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messageHolders);
        }
    }
}
