using Microsoft.EntityFrameworkCore;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;

namespace SmsHub.Persistence.Features.Contact.Commands.Implementations
{
    public class ContactNumberCommandService: IContactNumberCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ContactNumber> _contactNumbers;

        public ContactNumberCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _contactNumbers = _uow.Set<Entities.ContactNumber>();
        }
        public async Task Add(Entities.ContactNumber contactNumber)
        {
            await _contactNumbers.AddAsync(contactNumber);
        }
        public async Task Add(ICollection<Entities.ContactNumber> contactNumbers)
        {
            await _contactNumbers.AddRangeAsync(contactNumbers);
        }
    }

}
