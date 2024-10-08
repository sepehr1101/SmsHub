using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Commands.Contracts
{
    public interface IConsumerSafeIpCommandService
    {
        Task Add(ConsumerSafeIp consumerSafeIp);
        Task Add(ICollection<ConsumerSafeIp> consumerSafeIps);
        void Delete(ConsumerSafeIp consumerSafeIp);
    }
}
