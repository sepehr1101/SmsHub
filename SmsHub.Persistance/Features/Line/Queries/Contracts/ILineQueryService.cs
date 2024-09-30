using SmsHub.Domain.Constants;
using Entities =SmsHub. Domain.Features.Entities;
namespace SmsHub.Persistence.Features.Line.Queries.Contracts
{
    public interface ILineQueryService
    {
        Task<ICollection<Entities.Line>> Get();
        Task<Entities.Line> Get(ProviderEnum id);
    }
}
