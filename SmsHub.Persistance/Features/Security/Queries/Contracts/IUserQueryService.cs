using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface IUserQueryService
    {
        Task<ICollection<User>> Get();
        Task<User> Get(Guid id);
        Task<User?> Get(string username);
    }
}