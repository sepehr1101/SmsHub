using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var disallowedPhrases = await _getListHandler.Handle();

            //add InformativeLog
            var informativeLog = new CreateInformativeLogDto()// *** UserID;
            {
                LogLevelId = LogLevelEnum.InternalOperation,
                Section = LogLevelMessageResources.SendConfigSection,
                Description = LogLevelMessageResources.GetDisallowedPhraseDescription (disallowedPhrases.Count),
                UserId = new Guid(),//userId
                UserInfo = " "
            };
            await _informativeLogCreateHandler.Handle(informativeLog, cancellationToken);

            return Ok(disallowedPhrases);
        }

    }
}
