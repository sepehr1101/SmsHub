using Microsoft.Extensions.Logging;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface ILogLevelQueryService
    {
        Task<ICollection<LogLevel>> Get();
        Task<LogLevel> Get(ProviderEnum id);
    }
}
