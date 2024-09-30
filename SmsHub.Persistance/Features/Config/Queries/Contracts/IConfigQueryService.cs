namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IConfigQueryService
    {
        Task<ICollection<Domain.Features.Entities.Config>> Get();
        Task<Domain.Features.Entities.Config> Get(int id);
    }
}
