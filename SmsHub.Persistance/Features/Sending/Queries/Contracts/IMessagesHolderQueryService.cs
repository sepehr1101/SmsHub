using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessagesHolderQueryService
    {
        Task<ICollection<MessagesHolder>> Get();
        Task<MessagesHolder> Get(Guid id);
    }
}
