using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Security.Queries.Contracts
{
    public interface IServerUserQueryService
    {
        Task<ServerUser> GetById(int id);
        Task<ServerUser?> GetByApiKey(string apiKey);
        Task<bool> Any(string apiKey);
        Task<ICollection<ServerUser>> GetAll();
    }
}