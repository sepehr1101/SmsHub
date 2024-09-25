namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface IOperationTypeQueryService
    {
        Task<ICollection<Domain.Features.Entities.OperationType>> Get();
        Task<Domain.Features.Entities.OperationType> Get(int id);
    }
}
