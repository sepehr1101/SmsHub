using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Logging.Commands.Delete
{
    [Route(nameof(DeepLog))]
    [ApiController]
    [Authorize]
    public class DeepLogDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IDeepLogDeleteHandler _deleteCommandHandler;
        public DeepLogDeleteController(
            IUnitOfWork uow, 
            IDeepLogDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteDeepLogDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.DeepLog + LogLevelMessageResources.DeleteDescription)]
        public async Task<IActionResult> Delete([FromBody] DeleteDeepLogDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
