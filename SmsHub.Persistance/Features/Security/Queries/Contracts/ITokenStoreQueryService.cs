using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface ITokenStoreQueryService
    {
        Task<UserToken?> Get(string refreshTokenHash);
    }
}