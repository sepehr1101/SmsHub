namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IConfigTypeGroupQueryService
    {
        Task<ICollection<Domain.Features.Entities.ConfigTypeGroup>> Get();
        Task<Domain.Features.Entities.ConfigTypeGroup> Get(int id);
    }
}
