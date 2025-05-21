using Entities= SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IConfigQueryService
    {
        Task<ICollection<Entities.Config>> Get();
        Task<Entities.Config> Get(int id);
        Task<ICollection<Entities.Config>> GetByConfigTypeGroupId(int id);
    }
}
