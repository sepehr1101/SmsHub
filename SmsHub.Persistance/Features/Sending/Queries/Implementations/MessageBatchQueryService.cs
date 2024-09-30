using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessageBatchQueryService: IMessageBatchQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessageBatch> _messageBatches;
        public MessageBatchQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _messageBatches = _uow.Set<Entities.MessageBatch>();
        }
        public async Task<ICollection<Entities.MessageBatch>> Get()
        {
            var entities = await _messageBatches.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.MessageBatch));
            return entities;
        }
        public async Task<Entities.MessageBatch> Get(int id)
        {
            var entity = await _messageBatches.FindAsync(id);
            entity.NotNull(nameof(Entities.MessageBatch));
            return entity;
        }
    }
}
