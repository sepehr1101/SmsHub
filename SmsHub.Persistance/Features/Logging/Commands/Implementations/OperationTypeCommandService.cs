using Microsoft.EntityFrameworkCore;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class OperationTypeCommandService: IOperationTypeCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.OperationType> _operations;
        public OperationTypeCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _operations = _uow.Set<Entities.OperationType>();
        }
        public async Task Add(Entities.OperationType operationType)
        {
            await _operations.AddAsync(operationType);
        }
        public async Task Add(ICollection<Entities.OperationType> operationTypes)
        {
            await _operations.AddRangeAsync(operationTypes);
        }
    }
}
