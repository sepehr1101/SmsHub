using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpMessagesService
    {
        Task<MagfaRequest.ReceivedMessagesDto> GetMessages(string domain, string username, string password);
    }
}
