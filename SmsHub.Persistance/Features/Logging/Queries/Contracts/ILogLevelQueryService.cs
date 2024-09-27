namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface ILogLevelQueryService
    {
        Task<ICollection<Domain.Features.Entities.LogLevel>> Get();
        Task<Domain.Features.Entities.LogLevel> Get(int id);
    }
}
