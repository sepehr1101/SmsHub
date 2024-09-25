namespace SmsHub.Persistence.Features.Consumer.Queries.Contracts
{
    public interface IConsumerQueryService
    {
        Task<ICollection<Domain.Features.Entities.Consumer>> Get();
        Task<Domain.Features.Entities.Consumer> Get(int id);
    }
}
