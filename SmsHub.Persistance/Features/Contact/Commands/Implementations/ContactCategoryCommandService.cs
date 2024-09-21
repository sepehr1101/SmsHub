using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;

namespace SmsHub.Persistence.Features.Contact.Commands.Implementations
{
    public class ContactCategoryCommandService: IContactCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ContactCategory> _contactCategories;

        public ContactCategoryCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactCategories = _uow.Set<Entities.ContactCategory>();
        }
        
        public async Task Add(Entities.ContactCategory contactCategory)
        {
            await _contactCategories.AddAsync(contactCategory);
        }
        public async Task Add(ICollection<Entities.ContactCategory> contactCategories)
        {
            await _contactCategories.AddRangeAsync(contactCategories);
        }
    }
}
