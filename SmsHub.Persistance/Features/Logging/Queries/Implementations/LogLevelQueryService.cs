using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public class LogLevelQueryService: ILogLevelQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.LogLevel> _logLevels;
        public LogLevelQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _logLevels = _uow.Set<Entities.LogLevel>();
        }
        public async Task<ICollection<Entities.LogLevel>> Get()
        {
            var entities = await _logLevels.AsNoTracking().ToListAsync();
            entities.NotNull(nameof(Entities.LogLevel));
            return entities;
        }
        public async Task<Entities.LogLevel> Get(int id)
        {
            var entity = await _logLevels.FindAsync(id);
            entity.NotNull(nameof(Entities.LogLevel));
            return entity;
        }
    }
}
