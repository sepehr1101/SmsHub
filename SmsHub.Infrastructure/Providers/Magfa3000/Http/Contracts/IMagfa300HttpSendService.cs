using MagfaRequest =  SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpSendService
    {
        Task<MagfaRequest.SendDto> SendMessage(string domain, string username, string password);
    }
}
