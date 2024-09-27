namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageStateQueryService
    {
        Task<ICollection<Domain.Features.Entities.MessageState>> Get();
        Task<Domain.Features.Entities.MessageState> Get(int id);
    }
}
