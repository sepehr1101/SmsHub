namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface IInformativeLogQueryService
    {
        Task<ICollection<Domain.Features.Entities.InformativeLog>> Get();
        Task<Domain.Features.Entities.InformativeLog> Get(int id);
    }
}
