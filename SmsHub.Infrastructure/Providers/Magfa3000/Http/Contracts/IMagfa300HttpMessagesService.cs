using MagfaResponse = SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpMessagesService
    {
        Task<MagfaResponse.ReceivedMessagesDto> GetMessages(string domain, string username, string password);
    }
}
