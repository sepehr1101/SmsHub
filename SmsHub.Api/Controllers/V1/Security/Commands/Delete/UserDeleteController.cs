using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Delete
{
    [Route("user")]
    [ApiController]
    [Authorize]
    public class UserDeleteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserDeleteHandler _userDeleteHandler;
        public UserDeleteController(
            IUnitOfWork uow,
            IUserDeleteHandler userDeleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userDeleteHandler = userDeleteHandler;
            _userDeleteHandler.NotNull(nameof(userDeleteHandler));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UserDeleteDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.User + LogLevelMessageResources.DeleteDescription)]
        public async Task<IActionResult> Delete([FromBody] UserDeleteDto deleteDto, CancellationToken cancellationToken)
        {
            await _userDeleteHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(deleteDto);
        }
    }
}
