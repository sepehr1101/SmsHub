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
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageState))]
    [ApiController]
    [Authorize]
    public class MessageStateGetListController : BaseController
    {
        private readonly IMessageStateGetListHandler _getListHandler;
        private readonly IUnitOfWork _uow;
        public MessageStateGetListController(IMessageStateGetListHandler getListHandler,
            IUnitOfWork uow)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetMessageStateDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageState + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var messageStates = await _getListHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messageStates);
        }
    }
}
