using Microsoft.EntityFrameworkCore;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Persistence.Features.Logging.Commands.Implementations
{
    public class LogLevelCommandService: ILogLevelCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.LogLevel> _logLevel;
        public LogLevelCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _logLevel=_uow.Set<Entities.LogLevel>();
        }
        public async Task Add(Entities.LogLevel logLevel)
        {
            await _logLevel.AddAsync(logLevel);
        }
        public async Task Add(ICollection<Entities.LogLevel> logLevels)
        {
            await _logLevel.AddRangeAsync(logLevels);   
        }


    }
}
