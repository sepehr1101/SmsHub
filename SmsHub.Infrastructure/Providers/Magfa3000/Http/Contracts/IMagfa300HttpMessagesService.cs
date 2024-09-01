using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;

namespace SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts
{
    public interface IMagfa300HttpMessagesService
    {
        Task<MagfaRequest.ReceivedMessagesDto> Message(ReceivedMessagesDto receivedMessagesDto);
    }
}
