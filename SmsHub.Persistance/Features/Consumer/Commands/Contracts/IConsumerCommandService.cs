using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Commands.Contracts
{
    public interface IConsumerCommandService
    {
        Task Add(Entities.Consumer consumer);
        Task Add(ICollection<Entities.Consumer> consumers);
        void Delete(Entities.Consumer consumer);
    }
}