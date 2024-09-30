using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactNumberCategoryQueryService: IContactNumberCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ContactNumberCategory> _contactNumberCategories;
        public ContactNumberCategoryQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactNumberCategories = _uow.Set<Entities.ContactNumberCategory>();
        }
        public async Task<ICollection<Entities.ContactNumberCategory>> Get()
        {
            var entities = await _contactNumberCategories.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.ContactNumberCategory));
            return entities;
        }
        public async Task<Entities.ContactNumberCategory> Get(int id)
        {
            var entity = await _contactNumberCategories.FindAsync(id);
            entity.NotNull(nameof(Entities.ContactNumberCategory));
            return entity;
        }
    }
}
