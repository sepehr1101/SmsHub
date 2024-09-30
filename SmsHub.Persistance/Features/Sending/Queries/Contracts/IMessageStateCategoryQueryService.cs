namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageStateCategoryQueryService
    {
        Task<ICollection<Domain.Features.Entities.MessageStateCategory>> Get();
        Task<Domain.Features.Entities.MessageStateCategory> Get(int id);
    }
}
