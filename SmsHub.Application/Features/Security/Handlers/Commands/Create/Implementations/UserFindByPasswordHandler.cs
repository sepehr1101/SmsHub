using Microsoft.AspNetCore.Http;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;
using System.Net.Http;

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

            var logInfoString = GetLogInfo();

            if (user == null)
            {
                 await GetUserLogin(InvalidLoginReasonEnum.InvalidUsername, false, false, input,user);
                //var userLogin = new UserLogin()
                //{
                //    Id = new Guid(),
                //    FirstStepSuccess = false,
                //    AppVersion = input.AppVersion,
                //    FirstStepDateTime = DateTime.Now,
                //    LogInfo = logInfoString,
                //    Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                //    InvalidLoginReasonId = InvalidLoginReasonEnum.InvalidUsername,
                //};
                //await _userLoginCommandService.Add(userLogin);

                return (user, false);

            }
            else//user is not null
            {
                var hashedPassword = await SecurityOperations.GetSha512Hash(input.Password);
                if (hashedPassword != user.Password)
                {
                     await GetUserLogin(InvalidLoginReasonEnum.InvalidPassword, true, true, input,user);
                    //var userLogin = new UserLogin()
                    //{
                    //    Id = new Guid(),
                    //    Username = input.Username,
                    //    WrongPassword = input.Password,
                    //    FirstStepSuccess = false,
                    //    AppVersion = input.AppVersion,
                    //    FirstStepDateTime = DateTime.Now,
                    //    LogInfo = logInfoString,
                    //    Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                    //    InvalidLoginReasonId = InvalidLoginReasonEnum.InvalidPassword,
                    //};
                    //await _userLoginCommandService.Add(userLogin);

                    return (user, false);
                }
                else if (user.InvalidLoginAttemptCount > 3)//UserName , Password valid --> LockedUser
                {
                    await GetUserLogin(InvalidLoginReasonEnum.LockedUser, true, true, input, user);//todo: FirstStepSuccess false|true
                    //var userLogin = new UserLogin()
                    //{
                    //    Id = new Guid(),
                    //    UserId=user.Id,
                    //    Username = input.Username,
                    //    WrongPassword = input.Password,
                    //    FirstStepSuccess = false,//todo : true or not??
                    //    AppVersion = input.AppVersion,
                    //    FirstStepDateTime = DateTime.Now,
                    //    LogInfo = logInfoString,
                    //    Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                    //    InvalidLoginReasonId =InvalidLoginReasonEnum.LockedUser,
                    //};
                    //await _userLoginCommandService.Add(userLogin);

                    return (user, false);
                }
                else if (user.LockTimespan > DateTime.Now)//Inactive User
                {
                    await GetUserLogin(InvalidLoginReasonEnum.InactiveUser, true, true, input, user);//todo: FirstStepSuccess false|true
                    //var userLogin = new UserLogin()
                    //{
                    //    Id = new Guid(),
                    //    UserId = user.Id,
                    //    Username = input.Username,
                    //    WrongPassword = input.Password,
                    //    FirstStepSuccess = false,//todo : true or not??
                    //    AppVersion = input.AppVersion,
                    //    FirstStepDateTime = DateTime.Now,
                    //    LogInfo = logInfoString,
                    //    Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                    //    InvalidLoginReasonId = InvalidLoginReasonEnum.InactiveUser,
                    //};
                    //await _userLoginCommandService.Add(userLogin);

                    return (user, false);
                }
                else//valid
                {
                    //todo: when user validation was true, create userLogin or not??
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

        public async Task GetUserLogin(InvalidLoginReasonEnum LoginReasonEnum, bool IsUserName, bool IsPassword, FirstStepLoginInput input,User? user)
        {
            var userLogin = new UserLogin()
            {
                Id = new Guid(),
                Username=IsUserName? input.Username : null,
                WrongPassword=IsPassword? input.Password : null,
                UserId=user!=null? user.Id :null,//todo: true or not?
                FirstStepSuccess = false,
                AppVersion = input.AppVersion,
                FirstStepDateTime = DateTime.Now,
                LogInfo = GetLogInfo(),
                Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                InvalidLoginReasonId =LoginReasonEnum,
            };
            await _userLoginCommandService.Add(userLogin);
        }

    }
}
