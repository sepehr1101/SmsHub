using SmsHub.Application.Features.Auth.Handlers.Commands.Delete.Contracts;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Application.Features.Auth.Handlers.Commands.Delete.Implementations
{
    public class UserTokenDeleteHandler : IUserTokenDeleteHandler
    {
        private readonly ITokenStoreCommandService _tokenStoreCommandService;
        public UserTokenDeleteHandler(ITokenStoreCommandService tokenStoreCommandService)
        {
            _tokenStoreCommandService = tokenStoreCommandService;
        }
        public async Task Handle(Guid userId, CancellationToken cancellationToken)
        {
           await _tokenStoreCommandService.Remove(userId);
        }
    }
}
