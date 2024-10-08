using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageBatchCommandService: IMessageBatchCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageBatch> _messageBatches;
        public MessageBatchCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messageBatches=_uow.Set<MessageBatch>();
        }
        public async Task Add(MessageBatch messageBatch)
        {
            await _messageBatches.AddAsync(messageBatch);
        }
        public async Task Add(ICollection<MessageBatch> messageBatches)
        {
            await _messageBatches.AddRangeAsync(messageBatches);
        }
        public void Delete(MessageBatch messageBatch)
        {
            _messageBatches.Remove(messageBatch);
        }
    }
}
