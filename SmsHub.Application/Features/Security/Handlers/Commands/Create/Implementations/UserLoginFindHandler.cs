using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class UserLoginFindHandler : IUserLoginFindHandler
    {
        private readonly IUserLoginQueryService _userLoginQueryService;
        public UserLoginFindHandler(
            IUserLoginQueryService userLoginQueryService)
        {
            _userLoginQueryService = userLoginQueryService;
            _userLoginQueryService.NotNull(nameof(userLoginQueryService));
        }
        public async Task<(UserLogin, string)> Handle(SecondStepLoginInput input, CancellationToken cancellationToken)
        {
            var userLogin = await _userLoginQueryService.Get(input.Id);
            userLogin.NotNull(nameof(userLogin));
            userLogin.TwoStepCode.NotEmptyString(userLogin.TwoStepCode);
            if (userLogin.TwoStepCode != input.ConfirmCode)
            {
                return (userLogin, "کد وارد شده صحیح نمیباشد");
            }
            if (userLogin.TwoStepExpireDateTime > DateTime.Now)
            {
                return (userLogin, "زمان ورود کد منقضی شده است");
            }
            if (userLogin.TwoStepWasSuccessful.HasValue)
            {
                return (userLogin, "این کد قبلا استفاده شده است");
            }
            return (userLogin, string.Empty);
        }
    }
}
