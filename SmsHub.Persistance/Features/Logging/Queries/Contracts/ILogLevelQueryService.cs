using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface ILogLevelQueryService
    {
        Task<ICollection<LogLevel>> Get();
        Task<LogLevel> Get(LogLevelEnum id);
    }
}
