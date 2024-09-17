namespace SmsHub.Persistence.Features.Consumer.Commands.Contracts
{
    public interface IConsumerCommandService
    {
        Task Add(Domain.Features.Entities.Consumer consumer);
        Task Add(ICollection<Domain.Features.Entities.Consumer> consumers);
    }
}