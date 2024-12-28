using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactNumberQueryService: IContactNumberQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactNumber> _contactNumbers;
        public ContactNumberQueryService(IUnitOfWork uow)
        {
            _uow= uow;
            _uow.NotNull(nameof(_uow));

            _contactNumbers=_uow.Set<ContactNumber>();
            _contactNumbers.NotNull(nameof(_contactNumbers));
        }
        public async Task<ICollection<ContactNumber>> Get()
        {
            return await _contactNumbers.ToListAsync();
        }
        public async Task<ContactNumber> Get(int id)
        {
            return await _uow.FindOrThrowAsync<ContactNumber>(id);
        }
    }
}
