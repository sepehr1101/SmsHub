using MagfaResponse = SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpMidService
    {
        Task<MagfaResponse.MidDto> GetMid(string domain, string username, string password, long uid);
    }
}
