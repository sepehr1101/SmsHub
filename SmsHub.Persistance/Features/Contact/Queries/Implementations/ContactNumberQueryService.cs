using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactNumberQueryService: IContactNumberQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.ContactNumber> _contactNumbers;
        public ContactNumberQueryService(IUnitOfWork uow)
        {
            _uow= uow;
            _contactNumbers=_uow.Set<Entities.ContactNumber>();
        }
        public async Task<ICollection<Entities.ContactNumber>> Get()
        {
            var entities = await _contactNumbers.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.ContactNumber));
            return entities;
        }
        public async Task<Entities.ContactNumber> Get(int id)
        {
            var entity=await _contactNumbers.FindAsync(id);
            entity.NotNull(nameof(Entities.ContactNumber));
            return entity;
        }
    }
}
