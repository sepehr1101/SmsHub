using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public class DeepLogQueryService: IDeepLogQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<DeepLog> _deepLogs;
        public DeepLogQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _deepLogs = _uow.Set<DeepLog>();
            _deepLogs.NotNull(nameof(_deepLogs));
        }
        public async Task<ICollection<DeepLog>> Get()
        {
            return await _deepLogs.ToListAsync();
        }
        public async Task<DeepLog> Get(long  id)
        {
            return await _uow.FindOrThrowAsync<DeepLog>(id);
        }
    }
}
