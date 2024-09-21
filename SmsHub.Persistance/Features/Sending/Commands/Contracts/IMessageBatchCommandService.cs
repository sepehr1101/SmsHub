namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageBatchCommandService
    {
        Task Add(Domain.Features.Entities.MessageBatch messageBatch);
        Task Add(ICollection<Domain.Features.Entities.MessageBatch> messageBatches);
    }
}
