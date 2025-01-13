using Aban360.Api.Controllers.V1;
using DNTCaptcha.Core;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Auth.Services.Contracts;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Globalization;

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
        private readonly IDNTCaptchaApiProvider _captchaApiProvider;
        private readonly ICaptchaCryptoProvider _captchaCryptoProvider;

        public LoginController(
            IUnitOfWork uow,
            IUserFindByPasswordHandler userFindByPasswordHandler,
            ITokenFactoryService tokenFactoryService,
            IUserTokenCreateHandler userTokenCreateHandler,
            IUserLoginAddHandler userLoginAddHandler,
            IUserLoginFindHandler userLoginFindUserHandler,
            IDNTCaptchaApiProvider captchaApiProvider,
            ICaptchaCryptoProvider captchaCryptoProvider)
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

            _captchaApiProvider = captchaApiProvider;
            _captchaApiProvider.NotNull(nameof(captchaApiProvider));

            _captchaCryptoProvider = captchaCryptoProvider;
            _captchaCryptoProvider.NotNull(nameof(captchaCryptoProvider));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("first-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<FirstStepOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SecondStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceFirstStep([FromBody] FirstStepLoginInput loginDto, CancellationToken cancellationToken)
        {
            bool isCaptchaValid = HasRequestValidCaptchaEntry(loginDto);
            var (user, result) = await _userFindByPasswordHandler.Handle(loginDto, cancellationToken);
            if (!result || user is null)
            {
                return ClientError(MessageResources.UserNotFound);
            }
            if (!user.HasTwoStepVerification)
            {
                var secondStepOutput = await GetSecondStepOutput(user, cancellationToken);
                return Ok(secondStepOutput);
            }
            var output = await _userLoginAddHandler.Handle(loginDto, user);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(output, "second-step");
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
                return ClientError(MessageResources.InvalidConfirmCode);
            }
            var secondStepOutput = await GetSecondStepOutput(userLogin.User, cancellationToken);
            return Ok(secondStepOutput);
        }
        private async Task<SecondStepOutput> GetSecondStepOutput(User user, CancellationToken cancellationToken)
        {
            var jwtData = await _tokenFactoryService.CreateJwtTokensAsync(user);
            await _userTokenCreateHandler.Handle(jwtData, null, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return new SecondStepOutput(jwtData.AccessToken, jwtData.RefreshToken);
        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [Route("captcha")]
        public ActionResult<DNTCaptchaApiResponse> CreateDNTCaptchaParams()
        { 
            return _captchaApiProvider.CreateDNTCaptcha(new DNTCaptchaTagHelperHtmlAttributes
            {
                BackColor = "#f7f3f3",
                FontName = "Tahoma",
                FontSize = 20,
                ForeColor = "#111111",
                Language = DNTCaptcha.Core.Language.English,
                DisplayMode = DisplayMode.SumOfTwoNumbersToWords,
                Max = 90,
                Min = 1
            });
        }

        private bool HasRequestValidCaptchaEntry(FirstStepLoginInput input)
        {           
            if (string.IsNullOrEmpty(input.CaptchaText))
            {               
                return false;
            }
            if (string.IsNullOrEmpty(input.CaptchaInputText))
            {
                return false;
            }

            input.CaptchaInputText = input.CaptchaInputText.ToEnglishNumbers();

            if (!int.TryParse(input.CaptchaInputText, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                    CultureInfo.InvariantCulture, out var inputNumber))
            {
                return false;
            }

            var decryptedText = _captchaCryptoProvider.Decrypt(input.CaptchaText);
            var numberToText = inputNumber.ToString(CultureInfo.InvariantCulture);

            if (decryptedText?.Equals(numberToText, StringComparison.Ordinal) != true)
            {
                return false;
            }
            return true;
        }
    }
}
