using Aban360.Api.Controllers.V1;
using DNTCaptcha.Core;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Auth.Services.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.Globalization;
using System.Runtime.InteropServices;

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
        private readonly IUserPolicy _userPolicy;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;

        public LoginController(
            IUnitOfWork uow,
            IUserFindByPasswordHandler userFindByPasswordHandler,
            ITokenFactoryService tokenFactoryService,
            IUserTokenCreateHandler userTokenCreateHandler,
            IUserLoginAddHandler userLoginAddHandler,
            IUserLoginFindHandler userLoginFindUserHandler,
            IDNTCaptchaApiProvider captchaApiProvider,
            ICaptchaCryptoProvider captchaCryptoProvider,
            IUserPolicy userPolicy,
            IInformativeLogCreateHandler informativeLogCreateHandler)
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

            _userPolicy = userPolicy;
            _userPolicy.NotNull(nameof(userPolicy));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));
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
                await AddInformativeLogByNullUser
                (
                    LogLevelMessageResources.Login + $"مرحله اول - نام کاربری/رمزعبور:{loginDto.Username} ناصحیح",
                    cancellationToken
                );
                await _uow.SaveChangesAsync(cancellationToken);

                return ClientError(MessageResources.UserNotFound);
            }

            //Policy
            var (userPolicy, resultPolicy) = await _userPolicy.Handle(loginDto, cancellationToken);
            if (!resultPolicy || !string.IsNullOrEmpty(userPolicy))
            {
                await AddInformativeLog
               (
                   LogLevelMessageResources.Login + "مرحله اول - نقض policy",
                   cancellationToken,
                   user.Id,
                   user.FullName
               );
                await _uow.SaveChangesAsync(cancellationToken);

                return ClientError(userPolicy);
            }

            if (!user.HasTwoStepVerification)
            {
                var secondStepOutput = await GetSecondStepOutput(user, cancellationToken);

                await AddInformativeLog
              (
                  LogLevelMessageResources.Login + "مرحله اول -  عدم نیاز به ورود دو مرحله",
                  cancellationToken,
                   user.Id,
                   user.FullName
              );
                await _uow.SaveChangesAsync(cancellationToken);

                return Ok(secondStepOutput);
            }
            var output = await _userLoginAddHandler.Handle(loginDto, user);

            await AddInformativeLog
              (
                  LogLevelMessageResources.Login + "مرحله اول - ورود کاربر به مرحله دوم احراز هویت",
                  cancellationToken,
                   user.Id,
                   user.FullName
              );

            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(output, "second-step");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("second-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SecondStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceSecondStep([FromBody] SecondStepLoginInput loginDto, CancellationToken cancellationToken)
        {
            var (userLogin, errorMessage) = await _userLoginFindHandler.Handle(loginDto, cancellationToken);
            if (string.IsNullOrEmpty(errorMessage))
            {
                await AddInformativeLog
                  (
                      LogLevelMessageResources.Login + "مرحله دوم - عدم احراز موفق ",
                      cancellationToken,
                      userLogin.UserId,
                      userLogin.User.FullName
                  );
                await _uow.SaveChangesAsync(cancellationToken);

                throw new MessageException(errorMessage);
            }
            var secondStepOutput = await GetSecondStepOutput(userLogin.User, cancellationToken);

            await AddInformativeLog
              (
                  LogLevelMessageResources.Login + "مرحله دوم - ورود کاربر تایید شد",
                  cancellationToken,
                  userLogin.UserId,
                  userLogin.User.FullName
              );
            await _uow.SaveChangesAsync(cancellationToken);

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
        [ProducesResponseType(typeof(ApiResponseEnvelope<DNTCaptchaApiResponse>), StatusCodes.Status200OK)]
        public IActionResult CreateCaptchaParams()
        {
            var captchaParams = _captchaApiProvider.CreateDNTCaptcha(new DNTCaptchaTagHelperHtmlAttributes
            {
                BackColor = "#FFFFFF",
                FontName = "Tahoma",
                FontSize = 20,
                ForeColor = "#111111",
                Language = DNTCaptcha.Core.Language.Persian,
                DisplayMode = DisplayMode.SumOfTwoNumbers,
                Max = 90,
                Min = 5
            });
            return Ok(captchaParams);
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


        private async Task AddInformativeLog(string description, CancellationToken cancellationToken, [Optional] Guid? userId, [Optional] string? fullName)
        {
            CreateInformativeLogDto informativeLogDto = new
            (
                      LogLevelEnum.Security,
                      LogLevelMessageResources.SecuritySection,
                      description,
                      userId ?? CurrentUser.UserId,
                      fullName ?? CurrentUser.FullName
            );
            await _informativeLogCreateHandler.Handle(informativeLogDto, cancellationToken);
        }

        private async Task AddInformativeLogByNullUser(string description, CancellationToken cancellationToken)
        {
            CreateInformativeLogDto informativeLogDto = new
            (
                      LogLevelEnum.Security,
                      LogLevelMessageResources.SecuritySection,
                      description,
                      null,
                      string.Empty
            );
            await _informativeLogCreateHandler.Handle(informativeLogDto, cancellationToken);
        }
    }
}
