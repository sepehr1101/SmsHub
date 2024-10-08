using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class OperationTypeCommandService: IOperationTypeCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<OperationType> _operationTypes;
        public OperationTypeCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _operationTypes = _uow.Set<OperationType>();
        }
        public async Task Add(OperationType operationType)
        {
            await _operationTypes.AddAsync(operationType);
        }
        public async Task Add(ICollection<OperationType> operationTypes)
        {
            await _operationTypes.AddRangeAsync(operationTypes);
        }
        public void Delete(OperationType operationType)
        {
            _operationTypes.Remove(operationType);
        }
    }
}
