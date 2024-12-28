using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessagesDetailQueryService
    {
        Task<ICollection<MessagesDetail>> Get();
        Task<MessagesDetail> Get(long id);
    }
}
