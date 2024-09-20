using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Persistence.Features.Sending.Commands.Implementations
{
    public class MessageBatchCommandService: IMessageBatchCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessageBatch> _messageBatches;
        public MessageBatchCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _messageBatches=_uow.Set<Entities.MessageBatch>();
        }
        public async Task Add(Entities.MessageBatch messageBatch)
        {
            await _messageBatches.AddAsync(messageBatch);
        }
        public async Task Add(ICollection<Entities.MessageBatch> messageBatches)
        {
            await _messageBatches.AddRangeAsync(messageBatches);
        }
    }
}
