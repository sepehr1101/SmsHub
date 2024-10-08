using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class LogLevelCommandService: ILogLevelCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<LogLevel> _logLevel;
        public LogLevelCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _logLevel=_uow.Set<LogLevel>();
        }
        public async Task Add(LogLevel logLevel)
        {
            await _logLevel.AddAsync(logLevel);
        }
        public async Task Add(ICollection<LogLevel> logLevels)
        {
            await _logLevel.AddRangeAsync(logLevels);   
        }
        public void Delete(LogLevel logLevel)
        {
            _logLevel.Remove(logLevel);
        }


    }
}
