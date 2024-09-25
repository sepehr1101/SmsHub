namespace SmsHub.Persistence.Features.Line.Queries.Contracts
{
    public interface IProviderQueryService
    {
        Task<ICollection<Domain.Features.Entities.Provider>> Get();
        Task<Domain.Features.Entities.Provider> Get(int id);
    }
}
