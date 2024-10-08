using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Implementations
{
    public class ContactNumberCommandService: IContactNumberCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactNumber> _contactNumbers;

        public ContactNumberCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactNumbers = _uow.Set<ContactNumber>();
        }
        public async Task Add(ContactNumber contactNumber)
        {
            await _contactNumbers.AddAsync(contactNumber);
        }
        public async Task Add(ICollection<ContactNumber> contactNumbers)
        {
            await _contactNumbers.AddRangeAsync(contactNumbers);
        }
        public void Delete(ContactNumber contactNumber)
        {
            _contactNumbers.Remove(contactNumber);
        }
    }

}
