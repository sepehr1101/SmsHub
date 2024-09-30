namespace SmsHub.Persistence.Features.Consumer.Queries.Contracts
{
    public interface IConsumerSafeIpQueryService
    {
        Task<ICollection<Domain.Features.Entities.ConsumerSafeIp>> Get();
        Task<Domain.Features.Entities.ConsumerSafeIp> Get(int id);
    }
}
