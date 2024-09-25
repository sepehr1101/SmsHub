using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public class OperationTypeQueryService: IOperationTypeQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.OperationType> _operationTypes;
        public OperationTypeQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _operationTypes = _uow.Set<Entities.OperationType>();
        }
        public async Task<ICollection<Entities.OperationType>> Get()
        {
            var entities = await _operationTypes.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.OperationType));
            return entities;
        }
        public async Task<Entities.OperationType> Get(int id)
        {
            var entity = await _operationTypes.FindAsync(id);
            entity.NotNull(nameof(Entities.OperationType));
            return entity;
        }
    }
}
