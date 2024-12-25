using SmsHub.Application.Features.Sending.ServicesSample.Implementations;
using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.ServicesSample.Contracts
{
    public interface ISwitchingFactory
    {
        Task GetAccount_Balance(ProviderEnum lineId);
        Task GetStatusByMessageId(ProviderEnum lineId, int messageId);
        Task GetReceiveMessages(ProviderEnum lineId, int? count, string? LineNumber);
        Task SendMessages(ProviderEnum lineId, List<SendMessageDto> sendMessage);
        Task GetStatusByLocalMessageId(ProviderEnum lineId, long localMessageId);
        Task GetMessageIdByUserId(ProviderEnum lineId, long userId);
        Task GetMessageInfoByMessageId(ProviderEnum lineId, long messageId);
        Task GetMessageListSent(ProviderEnum lineId, long startDate, long endDate, string lineNumber);
        Task GetLatestMessageByMessageCount(ProviderEnum lineId, long count, string lineNumber);
        Task GetMessageCountInbox(ProviderEnum lineId, long startDate, long endDate, string lineNumber, bool IsRead);
    }

}
