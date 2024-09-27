namespace SmsHub.Persistence.Features.Line.Queries.Contracts
{
    public interface ILineQueryService
    {
        Task<ICollection<Domain.Features.Entities.Line>> Get();
        Task<Domain.Features.Entities.Line> Get(int id);
    }
}
