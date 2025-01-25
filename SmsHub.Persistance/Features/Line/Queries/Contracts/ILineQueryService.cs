using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using Entities =SmsHub. Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Line.Queries.Contracts
{
    public interface ILineQueryService
    {
        Task<ICollection<Entities.Line>> Get();
        Task<Entities.Line> Get(int id);
        Task<Entities.Line> GetIncludeProvider(int id);
        Task<ICollection<LineDictionary>> GetLineDictionary();
    }
}
