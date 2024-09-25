namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IPermittedTimeQueryService
    {
        Task<ICollection<Domain.Features.Entities.PermittedTime>> Get();
        Task<Domain.Features.Entities.PermittedTime> Get(int id);
    }
}
