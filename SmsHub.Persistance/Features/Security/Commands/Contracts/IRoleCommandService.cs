using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface IRoleCommandService
    {
        Task Add(Role role);
        //void Remove(Role role, string removeLogInfo);
    }
}