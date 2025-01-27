using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Create
{
    [Route("user")]
    [Authorize]
    public class UserCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserCreateHandler _createUserHandler;
        public UserCreateController(
            IUnitOfWork uow,
            IUserCreateHandler userCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _createUserHandler = userCreateHandler;
            _createUserHandler.NotNull(nameof(_createUserHandler));
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UserCreateDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> CreateUser([FromBody]UserCreateDto userCreateDto, CancellationToken cancellationToken)
        {
            await _createUserHandler.Handle(userCreateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(userCreateDto);
        }

        [Route("test")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Test()
        {
            throw new InvalidLineException();
            return Ok();
        }
    }
}
