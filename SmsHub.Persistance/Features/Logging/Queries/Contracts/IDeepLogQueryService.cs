using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface IDeepLogQueryService
    {
        Task<ICollection<DeepLog>> Get();
        Task<DeepLog> Get(long id);
    }
}
