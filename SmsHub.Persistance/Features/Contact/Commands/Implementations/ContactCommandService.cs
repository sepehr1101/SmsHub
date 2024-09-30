using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Implementations
{
    public class ContactCommandService: IContactCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Contact> _contacts;
        public ContactCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _contacts=_uow.Set<Entities.Contact>();
        }
        public async Task Add(Entities.Contact contact)
        {
            await _contacts.AddAsync(contact);
        }
        public async Task Add(ICollection<Entities.Contact> contact)
        {
            await _contacts.AddRangeAsync(contact);
        }
        public void Delete(Entities.Contact contact)
        {
            _contacts.Remove(contact);
        }
    }
}
