using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Sending.Queries.Implementations
{
    public class MessageStateCategoryQueryService: IMessageStateCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.MessageStateCategory> _messageStateCategories;
        public MessageStateCategoryQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _messageStateCategories = _uow.Set<Entities.MessageStateCategory>();
        }
        public async Task<ICollection<Entities.MessageStateCategory>> Get()
        {
            var entities = await  _messageStateCategories.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.MessageStateCategory));
            return entities;
        }
        public async Task<Entities.MessageStateCategory> Get(int id)
        {
            var entity = await  _messageStateCategories.FindAsync(id);
            entity.NotNull(nameof(Entities.MessageStateCategory));
            return entity;
        }
    }
}
