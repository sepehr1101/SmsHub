using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Logging.Commands.Delete
{
    [Route(nameof(OperationType))]
    [ApiController]
    public class OperationTypeDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IOperationTypeDeleteHandler _deleteCommandHandler;
        public OperationTypeDeleteController(
            IUnitOfWork uow, 
            IOperationTypeDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteOperationTypeDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Delete([FromBody] DeleteOperationTypeDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
