namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IConfigTypeQueryService
    {
        Task<ICollection<Domain.Features.Entities.ConfigType>> Get();
        Task<Domain.Features.Entities.ConfigType> Get(int id);
    }
}
