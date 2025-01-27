using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route("disallowed-phrase")]
    [ApiController]
    [Authorize]
    public class DisallowedPhraseGetListController : BaseController
    {
        private readonly IDisallowedPhraseGetListHandler _getListHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;

        public DisallowedPhraseGetListController(
            IDisallowedPhraseGetListHandler getListHandler, 
            IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
        }

        [HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetDisallowedPhraseDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.GetSumDisallowedPhraseDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var disallowedPhrases = await _getListHandler.Handle();
            return Ok(disallowedPhrases);
        }

    }
}
