using SmsHub.Domain.Features.Sending.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IProviderDeliveryStatusQueryService
    {
        Task<ProviderDeliveryStatus> Get(int id);
        Task<ICollection<ProviderDeliveryStatus>> Get();
    }
}
