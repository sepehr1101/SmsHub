using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Contact.Queries.Implementations
{
    public class ContactQueryService: IContactQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.Contact> _contacts;
        public ContactQueryService(IUnitOfWork uow)
        {
            _uow=uow;
            _uow.NotNull(nameof(_uow));

            _contacts=_uow.Set<Entities.Contact>();
            _contacts.NotNull(nameof(_contacts));
        }
        public async Task<ICollection<Entities.Contact>> Get()
        {
            return await _contacts.ToListAsync();
        }
        public async Task<Entities.Contact> Get(int id)
        {
            return await _uow.FindOrThrowAsync<Entities.Contact>(id);
        }
    }
}
