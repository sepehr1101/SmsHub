using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactCategoryQueryService: IContactCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ContactCategory> _contactCategories;
        public ContactCategoryQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _contactCategories=_uow.Set<Entities.ContactCategory>();
        }
        public async Task<ICollection<Entities.ContactCategory>> Get()
        {
            var entities = await _contactCategories.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.ContactCategory));
            return entities;
        }
        public async Task<Entities.ContactCategory> Get(int id)
        {
            var entity=await _contactCategories.FindAsync(id);
            entity.NotNull(nameof(Entities.ContactCategory));
            return entity;
        }


    }
}
