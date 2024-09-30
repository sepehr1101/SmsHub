namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessagesHolderQueryService
    {
        Task<ICollection<Domain.Features.Entities.MessagesHolder>> Get();
        Task<Domain.Features.Entities.MessagesHolder> Get(int id);
    }
}
