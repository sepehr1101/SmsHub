using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Implementations
{
    public class ContactCategoryCommandService: IContactCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactCategory> _contactCategories;

        public ContactCategoryCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactCategories = _uow.Set<ContactCategory>();
        }
        
        public async Task Add(ContactCategory contactCategory)
        {
            await _contactCategories.AddAsync(contactCategory);
        }
        public async Task Add(ICollection<ContactCategory> contactCategories)
        {
            await _contactCategories.AddRangeAsync(contactCategories);
        }
        public void Delete(ContactCategory contactCategory)
        {
            _contactCategories.Remove(contactCategory);
        }
    }
}
