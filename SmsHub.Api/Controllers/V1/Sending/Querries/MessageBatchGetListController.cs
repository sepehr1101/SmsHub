using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    [Authorize]
    public class MessageBatchGetListController : BaseController
    {
        private readonly IMessageBatchGetListHandler _getListHandler;
        private readonly IUnitOfWork _uow;
        public MessageBatchGetListController(IMessageBatchGetListHandler getListHandler,
            IUnitOfWork uow)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetMessageBatchDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageBatch + LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var messageBatchs = await _getListHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(messageBatchs);
        }
    }
}
