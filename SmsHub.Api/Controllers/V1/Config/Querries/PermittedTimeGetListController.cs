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
    [Route("permitted-time")]
    [ApiController]
    public class PermittedTimeGetListController : BaseController
    {
        private readonly IPermittedTimeGetListHandler _getListHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;

        public PermittedTimeGetListController(
            IPermittedTimeGetListHandler getListHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
        }

        [HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetPermittedTimeDto>>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var permittedTimes = await _getListHandler.Handle();

            //add InformativeLog
            var informativeLog = new CreateInformativeLogDto()// *** UserID;
            {
                LogLevelId = LogLevelEnum.InternalOperation,
                Section = LogLevelMessageResources.SendConfigSection,
                Description = LogLevelMessageResources.GetPermittedTimeDescription(permittedTimes.Count),
                UserId = new Guid(),//userId
                UserInfo = " "
            };
            await _informativeLogCreateHandler.Handle(informativeLog, cancellationToken);

            return Ok(permittedTimes);
        }
    }
}
