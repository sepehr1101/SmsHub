using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface IDeepLogCommandService
    {
        Task Add(DeepLog deepLog);
        Task Add(ICollection<DeepLog> deepLogs);
        void Delete(DeepLog deepLog);
    }
}
