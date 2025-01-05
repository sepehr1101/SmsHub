using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface IUserRoleCommandService
    {
        Task Add(ICollection<UserRole> userRoles);
        void Remove(ICollection<UserRole> userRoles, string logInfo);
    }
}