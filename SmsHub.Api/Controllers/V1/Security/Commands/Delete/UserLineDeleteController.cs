using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Delete
{
    [Route("user-line")]
    [ApiController]
    [Authorize]
    public class UserLineDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserLineDeleteHandler _userLineDeleteHandler;

        public UserLineDeleteController(
            IUnitOfWork uow,
            IUserLineDeleteHandler userLineDeleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userLineDeleteHandler = userLineDeleteHandler;
            _userLineDeleteHandler.NotNull(nameof(userLineDeleteHandler));
        }

        [Route("delete")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DeleteUserLineDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.UserLine + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserLineDto deleteDto, CancellationToken cancellationToken)
        {
            await _userLineDeleteHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(deleteDto);
        }
    }
}
