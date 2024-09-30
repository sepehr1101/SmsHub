using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactNumberCategoryQueryService
    {
        Task<ICollection<ContactNumberCategory>> Get();
        Task<ContactNumberCategory> Get(ProviderEnum id);
    }
}
