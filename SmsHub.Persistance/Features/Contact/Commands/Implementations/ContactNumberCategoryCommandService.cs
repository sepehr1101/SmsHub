using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;

namespace SmsHub.Persistence.Features.Contact.Commands.Implementations
{
    public class ContactNumberCategoryCommandService: IContactNumberCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ContactNumberCategory> _contactNumberCategories;
        public ContactNumberCategoryCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactNumberCategories = _uow.Set<Entities.ContactNumberCategory>();
        }
        public async Task Add(Entities.ContactNumberCategory contactNumberCategory)
        {
            await _contactNumberCategories.AddAsync(contactNumberCategory);
        }
        public async Task Add(ICollection<Entities.ContactNumberCategory> contactNumberCategories)
        {
            await _contactNumberCategories.AddRangeAsync(contactNumberCategories);
        }
    }
}
