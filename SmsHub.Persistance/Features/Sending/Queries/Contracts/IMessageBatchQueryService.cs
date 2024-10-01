using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageBatchQueryService
    {
        Task<ICollection<MessageBatch>> Get();
        Task<MessageBatch> Get(int id);
    }
}
