using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactCategoryQueryService: IContactCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactCategory> _contactCategories;
        public ContactCategoryQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _contactCategories=_uow.Set<ContactCategory>();
            _contactCategories.NotNull(nameof(_contactCategories));
        }
        public async Task<ICollection<ContactCategory>> Get()
        {
           return await _contactCategories.ToListAsync();
        }
        public async Task<ContactCategory> Get(int id)
        {
            return await _uow.FindOrThrowAsync<ContactCategory>(id);
        }


    }
}
