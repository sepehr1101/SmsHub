using SmsHub.Domain.Constants;
using Entities =SmsHub. Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Consumer.Queries.Contracts
{
    public interface IConsumerQueryService
    {
        Task<ICollection<Entities.Consumer>> Get();
        Task<Entities.Consumer> Get(int id);
    }
}
