using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageStateQueryService
    {
        Task<ICollection<MessageState>> Get();
        Task<MessageState> Get(long id);
    }
}
