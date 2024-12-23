using SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using MagfaResponse =  SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpSendService
    {
        Task<MagfaResponse.SendDto> SendMessage(string domain, string username, string password, SendDto value);
    }
}
