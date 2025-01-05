using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface IUserRoleQueryService
    {
        Task<ICollection<UserRole>> Get(Guid userId);
    }
}