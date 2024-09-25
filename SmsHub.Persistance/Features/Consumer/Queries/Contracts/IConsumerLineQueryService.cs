namespace SmsHub.Persistence.Features.Consumer.Queries.Contracts
{
    public interface IConsumerLineQueryService
    {
        Task<ICollection<Domain.Features.Entities.Consumer>> Get();
        Task<Domain.Features.Entities.Consumer> Get(int id);
    }
}