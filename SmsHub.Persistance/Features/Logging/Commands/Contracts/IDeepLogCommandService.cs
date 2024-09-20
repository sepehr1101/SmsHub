namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface IDeepLogCommandService
    {
        Task Add(Domain.Features.Entities.DeepLog deepLog);
        Task Add(ICollection<Domain.Features.Entities.DeepLog> deepLogs);
    }
}
