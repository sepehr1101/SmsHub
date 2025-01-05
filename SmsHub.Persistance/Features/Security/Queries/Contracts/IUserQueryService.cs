using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface IUserQueryService
    {
        Task<User> Get(Guid id);
        Task<User?> Get(string username);
    }
}