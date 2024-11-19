using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;

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
        public async Task<IActionResult> GetSingle([FromBody] IntId Id)
        {
            var logLevel = await _getSingleHandler.Handle(Id);
            return Ok(logLevel);
        }
    }
}
