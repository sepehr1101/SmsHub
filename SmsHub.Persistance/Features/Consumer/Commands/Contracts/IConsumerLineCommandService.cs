using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Commands.Contracts
{
    public interface IConsumerLineCommandService
    {
        Task Add(ConsumerLine consumerLine);
        Task Add(ICollection<ConsumerLine> consumerLines);
        void Delete(ConsumerLine consumerLine);
    }
}
