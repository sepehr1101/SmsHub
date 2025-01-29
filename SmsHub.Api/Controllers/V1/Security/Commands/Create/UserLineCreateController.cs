using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Create
{
    [Route("user-line")]
    [ApiController]
    [Authorize]
    public class UserLineCreateController : BaseController
    {
        private readonly IUserLineCreateHandler _userLineCreateHandler;
        private readonly IUnitOfWork _uow;

        public UserLineCreateController(
            IUnitOfWork uow,
            IUserLineCreateHandler userLineCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userLineCreateHandler = userLineCreateHandler;
            _userLineCreateHandler.NotNull(nameof(userLineCreateHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CreateUserLineDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.Security, LogLevelMessageResources.SecuritySection, LogLevelMessageResources.UserLine + LogLevelMessageResources.AddDescription)]
        public async Task<IActionResult> Create([FromBody] CreateUserLineDto userLineDto, CancellationToken cancellationToken)
        {
            await _userLineCreateHandler.Handle(userLineDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(userLineDto);
        }

    }

}
