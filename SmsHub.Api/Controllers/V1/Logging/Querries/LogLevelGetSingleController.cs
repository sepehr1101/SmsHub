using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Threading;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(LogLevel))]
    [ApiController]
    [Authorize]
    public class LogLevelGetSingleController : BaseController
    {
        private readonly ILogLevelGetSingleHandler _getSingleHandler;
        private readonly IUnitOfWork _uow;
        public LogLevelGetSingleController(
            ILogLevelGetSingleHandler getSingleHandler, 
            IUnitOfWork uow)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetLogLevelDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.LoggingSection, LogLevelMessageResources.LogLevel + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> GetSingle([FromBody] LogLevelEnum Id, CancellationToken cancellationToken)
        {
            var logLevel = await _getSingleHandler.Handle(Id);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(logLevel);
        }
    }
}
