using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Queries.Contracts
{
    public interface IConsumerSafeIpQueryService
    {
        Task<ICollection<ConsumerSafeIp>> Get();
        Task<ConsumerSafeIp> Get(ProviderEnum id);
    }
}
