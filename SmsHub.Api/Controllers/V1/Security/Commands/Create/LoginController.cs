using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Auth.Services.Contracts;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Security.Commands.Create
{
    [Route("login")]
    public class LoginController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserFindByPasswordHandler _userFindByPasswordHandler;
        private readonly ITokenFactoryService _tokenFactoryService;
        private readonly IUserTokenCreateHandler _userTokenCreateHandler;
        private readonly IUserLoginAddHandler _userLoginAddHandler;
        private readonly IUserLoginFindHandler _userLoginFindHandler;

        public LoginController(
            IUnitOfWork uow,
            IUserFindByPasswordHandler userFindByPasswordHandler,
            ITokenFactoryService tokenFactoryService,
            IUserTokenCreateHandler userTokenCreateHandler,
            IUserLoginAddHandler userLoginAddHandler,
            IUserLoginFindHandler userLoginFindUserHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userFindByPasswordHandler = userFindByPasswordHandler;
            _userFindByPasswordHandler.NotNull(nameof(_userFindByPasswordHandler));

            _tokenFactoryService = tokenFactoryService;
            _tokenFactoryService.NotNull(nameof(tokenFactoryService));

            _userTokenCreateHandler = userTokenCreateHandler;
            _userTokenCreateHandler.NotNull(nameof(userTokenCreateHandler));

            _userLoginAddHandler = userLoginAddHandler;
            _userLoginAddHandler.NotNull(nameof(userLoginAddHandler));

            _userLoginFindHandler = userLoginFindUserHandler;
            _userLoginFindHandler.NotNull(nameof(userLoginFindUserHandler));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("first-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<FirstStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceFirstStep([FromBody] FirstStepLoginInput loginDto, CancellationToken cancellationToken)
        {           
            var (user, result) = await _userFindByPasswordHandler.Handle(loginDto, cancellationToken);
            if(!result || user is null)
            {
                return ClientError("کاربر پیدا نشد");
            }
            var output = await _userLoginAddHandler.Handle(loginDto, user);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(output);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("second-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SecondStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceSecondStep([FromBody] SecondStepLoginInput loginDto, CancellationToken cancellationToken)
        {
            var userLogin = await _userLoginFindHandler.Handle(loginDto, cancellationToken);
            if (userLogin == null)
            {
                return ClientError("کد نامعتبر یا زمان آن منقضی شده است");
            }
            var jwtData = await _tokenFactoryService.CreateJwtTokensAsync(userLogin.User);
            await _userTokenCreateHandler.Handle(jwtData, null, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(new SecondStepOutput(jwtData.AccessToken, jwtData.RefreshToken));
        }
    }
}
