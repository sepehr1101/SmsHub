using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface IUserLoginQueryService
    {
        Task<UserLogin?> Get(Guid id);
    }
}