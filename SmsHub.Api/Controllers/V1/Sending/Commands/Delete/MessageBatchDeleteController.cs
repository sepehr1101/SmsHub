using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Delete
{
    [Route(nameof(MessageBatch))]
    [ApiController]
    [Authorize]
    public class MessageBatchDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMessageBatchDeleteHandler _deleteCommandHandler;
        public MessageBatchDeleteController(
            IUnitOfWork uow, 
            IMessageBatchDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteMessageBatchDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendSection, LogLevelMessageResources.MessageBatch + LogLevelMessageResources.DeleteDescription)]
        public async Task<IActionResult> Delete([FromBody] DeleteMessageBatchDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
