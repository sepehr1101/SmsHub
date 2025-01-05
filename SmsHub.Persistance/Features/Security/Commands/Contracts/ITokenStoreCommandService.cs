using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface ITokenStoreCommandService
    {
        Task Add(UserToken userToken);
        Task RemoveTokensWithSameRefreshTokenSource(Guid userId);
        Task Remove(Guid userId);
    }
}