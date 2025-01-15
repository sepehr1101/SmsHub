using SmsHub.Domain.Features.Sending.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IProviderResponseStatusQueryService
    {
        Task<ProviderResponseStatus> Get(int id);
        Task<ICollection<ProviderResponseStatus>> Get();
    }
}
