using SmsHub.Domain.Features.Sending.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageDetailStatusQueryService
    {
        Task<MessageDetailStatus> GetById(long Id);
        Task<MessageDetailStatus> GetByMessageId(long Id);
        Task<ICollection<MessageDetailStatus>> GetByStatusId(long Id);
        Task<ICollection<MessageDetailStatus>> GetByMessageDetailId(long Id);
        Task<ICollection<MessageDetailStatus>> GetAll();
    }
}
