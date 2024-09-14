using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Persistence.Features.Contact
{
    public interface IContactCategoryService
    {
        Task<ICollection<ContactCategory>> Get();
    }

    public class ContactCategoryService : IContactCategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactCategory> _contactCategories;
        public ContactCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactCategories = _uow.Set<ContactCategory>();
        }
        public async Task<ICollection<ContactCategory>> Get()
        {
            return await _contactCategories.ToListAsync();
        }
    }
}
