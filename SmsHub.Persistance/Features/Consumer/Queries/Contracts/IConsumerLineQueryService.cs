namespace SmsHub.Persistence.Features.Consumer.Queries.Contracts
{
    public interface IConsumerLineQueryService
    {
        Task<ICollection<Domain.Features.Entities.ConsumerLine>> Get();
        Task<Domain.Features.Entities.ConsumerLine> Get(int id);
    }
}