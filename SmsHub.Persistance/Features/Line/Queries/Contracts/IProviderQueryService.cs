using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Line.Queries.Contracts
{
    public interface IProviderQueryService
    {
        Task<ICollection<Provider>> Get();
        Task<Provider> Get(ProviderEnum id);
    }
}
