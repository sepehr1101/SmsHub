using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Delete
{
    [Route("line")]
    [ApiController]
    [Authorize]
    public class LineDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ILineDeleteHandler _deleteCommandHandler;
        public LineDeleteController(
            IUnitOfWork uow, 
            ILineDeleteHandler deleteCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _deleteCommandHandler = deleteCommandHandler;
            _deleteCommandHandler.NotNull(nameof(deleteCommandHandler));
        }
        [HttpPost]
        [Route("delete")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteLineDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LineSection, LogLevelMessageResources.Line + LogLevelMessageResources.DeleteDescription)]
        public async Task<IActionResult> Delete([FromBody] DeleteLineDto deleteDto, CancellationToken cancellationToken)
        {
            await _deleteCommandHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(deleteDto);
        }
    }
}
