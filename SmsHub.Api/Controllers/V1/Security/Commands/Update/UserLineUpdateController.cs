using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Update
{
    [Route("user-line")]
    [ApiController]
    [Authorize]
    public class UserLineUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserLineUpdateHandler _userLineUpdateHandler;
        public UserLineUpdateController(
            IUnitOfWork uow,
            IUserLineUpdateHandler userLineUpdateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userLineUpdateHandler = userLineUpdateHandler;
            _userLineUpdateHandler.NotNull(nameof(userLineUpdateHandler));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateUserLineDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.UserLine + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateUserLineDto updateDto, CancellationToken cancellationToken)
        {
            await _userLineUpdateHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(updateDto);
        }
    }
}
