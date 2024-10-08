using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Contracts
{
    public interface IMessageBatchCommandService
    {
        Task Add(MessageBatch messageBatch);
        Task Add(ICollection<MessageBatch> messageBatches);
        void Delete(MessageBatch messageBatch);
    }
}
