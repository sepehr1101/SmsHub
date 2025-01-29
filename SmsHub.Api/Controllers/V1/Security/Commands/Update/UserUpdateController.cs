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
    [Route("user")]
    [Authorize]
    public class UserUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserUpdateHandler _userUpdateHandler;
        public UserUpdateController(
            IUnitOfWork uow,
            IUserUpdateHandler userUpdateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userUpdateHandler= userUpdateHandler;
            _userUpdateHandler.NotNull(nameof(userUpdateHandler));
        }

        [HttpPost, HttpPatch]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UserUpdateDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.User + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto, CancellationToken cancellationToken)
        {
            await _userUpdateHandler.Handle(userUpdateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(userUpdateDto);
        }
    }
}