using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface IUserCommandService
    {
        Task Add(User user);
        void Remove(User user, string logInfo);
    }
}