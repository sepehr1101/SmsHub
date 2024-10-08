using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface ILogLevelCommandService
    {
        Task Add(LogLevel logLevel);
        Task Add(ICollection<LogLevel> logLevels);
        void Delete(LogLevel logLevel);
    }
}
