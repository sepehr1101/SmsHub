using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessagesDetailQueryService: IMessagesDetailQueryService
    {

        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessagesDetail> _messagesDetails;
        public MessagesDetailQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _messagesDetails = _uow.Set<Entities.MessagesDetail>();
        }
        public async Task<ICollection<Entities.MessagesDetail>> Get()
        {
            var entities = await _messagesDetails.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.MessagesDetail));
            return entities;
        }
        public async Task<Entities.MessagesDetail> Get(int id)
        {
            var entity = await _messagesDetails.FindAsync(id);
            entity.NotNull(nameof(Entities.MessagesDetail));
            return entity;
        }
    }
}
