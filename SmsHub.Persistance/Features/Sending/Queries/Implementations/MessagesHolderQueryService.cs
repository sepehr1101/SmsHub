using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessagesHolderQueryService: IMessagesHolderQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessagesHolder> _messagesHolders;
        public MessagesHolderQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _messagesHolders = _uow.Set<Entities.MessagesHolder>();
        }
        public async Task<ICollection<Entities.MessagesHolder>> Get()
        {
            var entities = await _messagesHolders.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.MessagesHolder));
            return entities;
        }
        public async Task<Entities.MessagesHolder> Get(int id)
        {
            var entity = await _messagesHolders.FindAsync(id);
            entity.NotNull(nameof(Entities.MessagesHolder));
            return entity;
        }
    }
}
