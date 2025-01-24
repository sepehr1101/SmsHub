using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface IUserCommandService
    {
        Task Add(User user);
        Task Remove(Guid userId, string logInfo);
        Task Remove(User user, string logInfo);
    }
}