namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface ILogLevelCommandService
    {
        Task Add(Domain.Features.Entities.LogLevel logLevel);
        Task Add(ICollection<Domain.Features.Entities.LogLevel> logLevels);
    }
}
