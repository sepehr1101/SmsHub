using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface IRoleQueryService
    {
        Task<ICollection<Role>> Get();
        Task<Role> Get(int id);
        Task<int> CheckRole(ICollection<int> roleIds);
    }
}