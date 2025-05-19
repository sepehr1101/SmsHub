using Microsoft.AspNetCore.Http;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class UserPolicy : IUserPolicy
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserLoginCommandService _userLoginCommandService;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserPolicy(
            IUserQueryService userQueryService,
             IUserLoginCommandService userLoginCommandService,
            IHttpContextAccessor contextAccessor)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

            _userLoginCommandService= userLoginCommandService;
            _userLoginCommandService.NotNull(nameof(userLoginCommandService));

            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));
        }

        public async Task<(string, bool)> Handle(FirstStepLoginInput input, CancellationToken cancellationToken)
        {
            var user = await _userQueryService.Get(input.Username);
            if (user.InvalidLoginAttemptCount > 3)
            {
               var userLogin= await GetUserLogin(InvalidLoginReasonEnum.LockedUser, input, user);
                await _userLoginCommandService.Add(userLogin);

                return ("به حداکثر تلاش مجاز رسیده اید",false);
            }
            else if (user.LockTimespan > DateTime.Now)
            {
                var userLogin = await GetUserLogin(InvalidLoginReasonEnum.InactiveUser, input, user);
                await _userLoginCommandService.Add(userLogin);

                var dateLock = user.LockTimespan.Value.Date;
                var timeLock=user.LockTimespan.Value.TimeOfDay;
                
                return ($"حساب کاربری شما تاریخ {dateLock} - ساعت {timeLock} قفل می باشد ", false);
            }
            else
            {
                return ("", true);
            }
        }

        public string GetLogInfo()
        {
            var logInfo = DeviceDetection.GetLogInfo(_contextAccessor.HttpContext.Request);
            var logInfoString = JsonOperation.Marshal(logInfo);

            return logInfoString;
        }

        private async Task<UserLogin> GetUserLogin(InvalidLoginReasonEnum LoginReasonEnum, FirstStepLoginInput input,
            User? user)
        {
            var userLogin = new UserLogin()
            {
                Id = new Guid(),
                Username = input.Username,
                WrongPassword =input.Password,
                UserId = user != null ? user.Id : null,
                FirstStepSuccess = false,
                AppVersion = input.AppVersion,
                FirstStepDateTime = DateTime.Now,
                LogInfo = GetLogInfo(),
                Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                InvalidLoginReasonId = LoginReasonEnum,
            };
            return userLogin;
        }
    }
}
