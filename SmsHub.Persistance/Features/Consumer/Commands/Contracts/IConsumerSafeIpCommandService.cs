namespace SmsHub.Persistence.Features.Consumer.Commands.Contracts
{
    public interface IConsumerSafeIpCommandService
    {
        Task Add(Domain.Features.Entities.ConsumerSafeIp consumerSafeIp);
        Task Add(ICollection<Domain.Features.Entities.ConsumerSafeIp> consumerSafeIps);
    }
}
