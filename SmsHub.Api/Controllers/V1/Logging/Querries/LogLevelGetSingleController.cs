using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(LogLevel))]
    [ApiController]
    public class LogLevelGetSingleController : BaseController
    {
        private readonly ILogLevelGetSingleHandler _getSingleHandler;
        public LogLevelGetSingleController(ILogLevelGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetLogLevelDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetSingle([FromBody] LogLevelEnum Id)
        {
            var logLevel = await _getSingleHandler.Handle(Id);
            return Ok(logLevel);
        }
    }
}
