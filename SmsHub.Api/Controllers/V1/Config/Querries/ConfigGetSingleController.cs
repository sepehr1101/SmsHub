using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route("config")]
    [ApiController]
    [Authorize]
    public class ConfigGetSingleController : BaseController
    {
        private readonly IConfigGetSingleHandler _getSingleHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;

        public ConfigGetSingleController(
            IConfigGetSingleHandler getSingleHandler, 
            IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetConfigDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.GetOneConfigDescription)]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id, CancellationToken cancellationToken)
        {
            var config = await _getSingleHandler.Handle(Id);           
            return Ok(config);
        }
    }
}
