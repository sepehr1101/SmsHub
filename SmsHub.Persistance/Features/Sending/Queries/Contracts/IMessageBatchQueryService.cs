namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageBatchQueryService
    {
        Task<ICollection<Domain.Features.Entities.MessageBatch>> Get();
        Task<Domain.Features.Entities.MessageBatch> Get(int id);
    }
}
