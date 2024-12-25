using magfaResponse= SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpStatusesService
    {
        Task<magfaResponse.StatusesDto> GetStatuses(string domain, string username, string password,long id);
        Task<magfaResponse.StatusesDto> GetStatuses(string domain, string username, string password, ICollection<long> id);
    }
}
