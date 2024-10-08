using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Implementations
{
    public class ContactNumberCategoryCommandService: IContactNumberCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactNumberCategory> _contactNumberCategories;
        public ContactNumberCategoryCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactNumberCategories = _uow.Set<ContactNumberCategory>();
        }
        public async Task Add(ContactNumberCategory contactNumberCategory)
        {
            await _contactNumberCategories.AddAsync(contactNumberCategory);
        }
        public async Task Add(ICollection<ContactNumberCategory> contactNumberCategories)
        {
            await _contactNumberCategories.AddRangeAsync(contactNumberCategories);
        }
        public void Delete(ContactNumberCategory contactNumberCategory)
        {
            _contactNumberCategories.Remove(contactNumberCategory);
        }
    }
}
