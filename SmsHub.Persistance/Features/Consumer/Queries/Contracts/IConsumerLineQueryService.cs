using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Queries.Contracts
{
    public interface IConsumerLineQueryService
    {
        Task<ICollection<ConsumerLine>> Get();
        Task<ConsumerLine> Get(int id);
    }
}