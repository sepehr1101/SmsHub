using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public class OperationTypeQueryService : IOperationTypeQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<OperationType> _operationTypes;
        public OperationTypeQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _operationTypes = _uow.Set<OperationType>();
            _operationTypes.NotNull(nameof(_operationTypes));
        }
        public async Task<ICollection<OperationType>> Get()
        {
            return await _operationTypes.ToListAsync();
        }
        public async Task<OperationType> Get(ProviderEnum id)
        {
            return await _uow.FindOrThrowAsync<OperationType>(id);
        }
    }
}
