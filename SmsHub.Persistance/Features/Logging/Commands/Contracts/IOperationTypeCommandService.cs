using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface IOperationTypeCommandService
    {
        Task Add(OperationType operationType);
        Task Add(ICollection<OperationType> operationTypes);
        void Delete(OperationType operationType);
    }
}
