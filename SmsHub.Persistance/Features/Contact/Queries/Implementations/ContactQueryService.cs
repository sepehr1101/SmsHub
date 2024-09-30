using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactQueryService: IContactQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Contact> _contacts;
        public ContactQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _contacts=_uow.Set<Entities.Contact>();
        }
        public async Task<ICollection<Entities.Contact>> Get()
        {
            var entities = await _contacts.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.Contact));
            return entities;
        }
        public async Task<Entities.Contact> Get(int id)
        {
            var entity=await _contacts.FindAsync(id);
            entity.NotNull(nameof(Entities.Contact));
            return entity;
        }
    }
}
