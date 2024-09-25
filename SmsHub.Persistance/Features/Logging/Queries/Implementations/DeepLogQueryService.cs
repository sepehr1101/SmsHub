using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public class DeepLogQueryService: IDeepLogQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.DeepLog> _deepLogs;
        public DeepLogQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _deepLogs = _uow.Set<Entities.DeepLog>();
        }
        public async Task<ICollection<Entities.DeepLog>> Get()
        {
            var entities = await _deepLogs.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.DeepLog));
            return entities;
        }
        public async Task<Entities.DeepLog> Get(int id)
        {
            var entity = await _deepLogs.FindAsync(id);
            entity.NotNull(nameof(Entities.DeepLog));
            return entity;
        }
    }
}
