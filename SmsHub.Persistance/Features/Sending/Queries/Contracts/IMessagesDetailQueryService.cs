namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessagesDetailQueryService
    {
        Task<ICollection<Domain.Features.Entities.MessagesDetail>> Get();
        Task<Domain.Features.Entities.MessagesDetail> Get(int id);
    }
}
