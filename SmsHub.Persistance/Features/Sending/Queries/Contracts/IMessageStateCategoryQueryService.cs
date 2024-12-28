using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageStateCategoryQueryService
    {
        Task<ICollection<MessageStateCategory>> Get();
        Task<MessageStateCategory> Get(int id);
    }
}
