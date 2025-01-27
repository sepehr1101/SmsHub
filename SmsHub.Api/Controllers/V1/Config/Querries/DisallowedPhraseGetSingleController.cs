using Aban360.Api.Controllers.V1;
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
    [Route("disallowed-phrase")]
    [ApiController]
    public class DisallowedPhraseGetSingleController : BaseController
    {
        private readonly IDisallowedPhraseGetSingleHandler _getSingleHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        public DisallowedPhraseGetSingleController(
            IDisallowedPhraseGetSingleHandler getSingleHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(_getSingleHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetDisallowedPhraseDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.GetOneDisallowedPhraseDescription)]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id, CancellationToken cancellationToken)
        {
            var disallowedPhrase = await _getSingleHandler.Handle(Id);
            return Ok(disallowedPhrase);
        }

    }
}
