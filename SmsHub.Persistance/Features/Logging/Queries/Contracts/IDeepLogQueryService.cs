namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface IDeepLogQueryService
    {
        Task<ICollection<Domain.Features.Entities.DeepLog>> Get();
        Task<Domain.Features.Entities.DeepLog> Get(int id);
    }
}
