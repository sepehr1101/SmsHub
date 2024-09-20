namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface IOperationTypeCommandService
    {
        Task Add(Domain.Features.Entities.OperationType operationType);
        Task Add(ICollection<Domain.Features.Entities.OperationType> operationTypes);
    }
}
