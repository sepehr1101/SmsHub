using SmsHub.Domain.Features.Logging.Entities;

namespace SmsHub.Persistence.Features.Logging.Queries.Contracts
{
    public interface IHttpLogQueryService
    {
        Task<HttpLog?> Get(long id);
    }
}