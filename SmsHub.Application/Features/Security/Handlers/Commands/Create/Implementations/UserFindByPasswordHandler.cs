using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class UserFindByPasswordHandler : IUserFindByPasswordHandler
    {
        private readonly IUserQueryService _userQueryService;
        public UserFindByPasswordHandler(
            IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(_userQueryService));
        }
        public async Task<(User?, bool)> Handle(FirstStepLoginInput input, CancellationToken cancellationToken)
        {
            var user = await _userQueryService.Get(input.Username);
            if (user is not null)
            {
                var hashedPassword = await SecurityOperations.GetSha512Hash(input.Password);
                if (hashedPassword != user.Password)
                {
                    return (user, false);
                }
                return (user, true);
            }
            return (null, false);
        }
    }
}
