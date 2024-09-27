using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessageStateQueryService: IMessageStateQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessageState> _messageStates;
        public MessageStateQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _messageStates = _uow.Set<Entities.MessageState>();
        }
        public async Task<ICollection<Entities.MessageState>> Get()
        {
            var entities = await _messageStates.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.MessageState));
            return entities;
        }
        public async Task<Entities.MessageState> Get(int id)
        {
            var entity = await _messageStates.FindAsync(id);
            entity.NotNull(nameof(Entities.MessageState));
            return entity;
        }
    }
}
