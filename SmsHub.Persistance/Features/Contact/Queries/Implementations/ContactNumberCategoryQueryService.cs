using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactNumberCategoryQueryService: IContactNumberCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactNumberCategory> _contactNumberCategories;
        public ContactNumberCategoryQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _contactNumberCategories = _uow.Set<ContactNumberCategory>();
            _contactNumberCategories.NotNull(nameof(_contactNumberCategories));
        }
        public async Task<ICollection<ContactNumberCategory>> Get()
        {
           return await _contactNumberCategories.ToListAsync();
        }
        public async Task<ContactNumberCategory> Get(int id)
        {
           return await _uow.FindOrThrowAsync<ContactNumberCategory>(id);
        }
    }
}
