using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactNumberQueryService
    {
        Task<ICollection<ContactNumber>> Get();
        Task<ContactNumber> Get(int id);
    }
}
