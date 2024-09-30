using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Security.Commands.Contracts
{
    public interface IServerUserCommandService
    {
        Task Add(ServerUser user);
        Task Remove(int id);
        Task UpdateApiKey(int id, string newApiKeyHash);
    }
}