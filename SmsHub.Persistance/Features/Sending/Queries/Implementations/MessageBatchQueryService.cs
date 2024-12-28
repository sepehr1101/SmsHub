using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessageBatchQueryService: IMessageBatchQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<MessageBatch> _messageBatches;
        public MessageBatchQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _messageBatches = _uow.Set<MessageBatch>();
            _messageBatches.NotNull(nameof(_messageBatches));
        }
        public async Task<ICollection<MessageBatch>> Get()
        {
           return await _messageBatches.ToListAsync();
        }
        public async Task<MessageBatch> Get(int id)
        {
            return await _uow.FindOrThrowAsync<MessageBatch>(id);
        }
    }
}
