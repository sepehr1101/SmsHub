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
    [Route("cc-send")]
    [ApiController]
    [Authorize]
    public class CcSendGetSingleController : BaseController
    {
        private readonly ICcSendGetSingleHandler _getSingleHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;

        public CcSendGetSingleController(
            ICcSendGetSingleHandler getSingleHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
        }

        [HttpPost]
        [Route("single")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<GetCcSendDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.GetOneCcSendDescription)]
        public async Task<IActionResult> GetSingle([FromBody] IntId Id, CancellationToken cancellationToken)
        {
            var ccSend = await _getSingleHandler.Handle(Id);           
            return Ok(ccSend);
        }
    }
}
