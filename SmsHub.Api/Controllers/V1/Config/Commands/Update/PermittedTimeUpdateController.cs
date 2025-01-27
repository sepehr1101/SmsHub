using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Update
{
    [Route("permitted-time")]
    [ApiController]
    public class PermittedTimeUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IPermittedTimeUpdateHandler _updateCommandHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;

        public PermittedTimeUpdateController(
            IUnitOfWork uow,
            IPermittedTimeUpdateHandler updateCommandHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
        }

        [HttpPost]
        [HttpPost("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdatePermittedTimeDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Update([FromBody] UpdatePermittedTimeDto updateDto, CancellationToken cancellationToken)
        {
            await _updateCommandHandler.Handle(updateDto, cancellationToken);

            //add InformativeLog
            var informativeLog = new CreateInformativeLogDto()// *** UserID;
            {
                LogLevelId = LogLevelEnum.InternalOperation,
                Section = LogLevelMessageResources.SendConfigSection,
                Description = LogLevelMessageResources.UpdatePermittedTimeDescription,
                UserId = new Guid(),//userId
                UserInfo = " "
            };
            await _informativeLogCreateHandler.Handle(informativeLog, cancellationToken);

            await _uow.SaveChangesAsync(cancellationToken);
           return Ok(updateDto);
        }
    }
}
