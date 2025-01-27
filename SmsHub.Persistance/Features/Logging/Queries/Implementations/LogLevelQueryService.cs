using SmsHub.Persistence.Features.Logging.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Logging.Queries.Implementations
{
    public class LogLevelQueryService: ILogLevelQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<LogLevel> _logLevels;
        public LogLevelQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _logLevels = _uow.Set<LogLevel>();
            _logLevels.NotNull(nameof(_logLevels));
        }
        public async Task<ICollection<LogLevel>> Get()
        {
            return await _logLevels.ToListAsync();
        }
        public async Task<LogLevel> Get(LogLevelEnum id)
        {
           return await _uow.FindOrThrowAsync<LogLevel>(id);
        }
    }
}
