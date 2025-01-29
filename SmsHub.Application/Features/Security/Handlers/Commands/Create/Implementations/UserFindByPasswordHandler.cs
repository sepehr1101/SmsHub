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
    public class UserFindByPasswordHandler : IUserFindByPasswordHandler
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserLoginCommandService _userLoginCommandService;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserFindByPasswordHandler(
            IUserQueryService userQueryService,
            IUserLoginCommandService userLoginCommandService,
            IHttpContextAccessor contextAccessor)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(_userQueryService));

            _userLoginCommandService = userLoginCommandService;
            _userLoginCommandService.NotNull(nameof(_userLoginCommandService));

            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(_contextAccessor));
        }
        public async Task<(User?, bool)> Handle(FirstStepLoginInput input, CancellationToken cancellationToken)
        {
            var user = await _userQueryService.Get(input.Username);
            if (user == null)
            {
                var userLogin = await GetUserLogin(InvalidLoginReasonEnum.InvalidUsername, input, user);
                await _userLoginCommandService.Add(userLogin);

                return (user, false);
            }
            else
            {
                var hashedPassword = await SecurityOperations.GetSha512Hash(input.Password);
                if (hashedPassword != user.Password)
                {
                    var userLogin = await GetUserLogin(InvalidLoginReasonEnum.InvalidPassword, input, user);
                    await _userLoginCommandService.Add(userLogin);

                    return (user, false);
                }
                else
                {
                    return (user, true);
                }
            }
        }
        public string GetLogInfo()
        {
            var logInfo = DeviceDetection.GetLogInfo(_contextAccessor.HttpContext.Request);
            var logInfoString = JsonOperation.Marshal(logInfo);

            return logInfoString;
        }

        private async Task<UserLogin> GetUserLogin(InvalidLoginReasonEnum loginReason, FirstStepLoginInput input, User? user)
        {
            var userLogin = new UserLogin()
            {
                Id = new Guid(),
                Username = input.Username,
                WrongPassword = input.Password,
                UserId = user != null ? user.Id : null,
                FirstStepSuccess = false,
                AppVersion = input.AppVersion,
                FirstStepDateTime = DateTime.Now,
                LogInfo = GetLogInfo(),
                Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                InvalidLoginReasonId = loginReason,
            };

            return userLogin;
        }

    }
}
