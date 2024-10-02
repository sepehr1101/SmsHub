using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface IInformativeLogQueryService
    {
        Task<ICollection<InformativeLog>> Get();
        Task<InformativeLog> Get(long id);
    }
}
