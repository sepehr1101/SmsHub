using SmsHub.Application.Features.Sending.ServicesSample.Implementations;

namespace SmsHub.Application.Features.Sending.ServicesSample.Contracts
{
    public interface ISwitchingFactory
    {
        Task GetAccount_Balance(int lineId);
        Task GetStatusByMessageId(int lineId, int messageId);
        Task GetReceiveMessages(int lineId,int? count,string? LineNumber);
        Task SendMessages(int lineId, List<SendMessageDto> sendMessage);
        Task GetStatusByLocalMessageId(int lineId, long localMessageId);
        Task GetMessageIdByUserId(int lineId,long userId);
        Task GetMessageInfoByMessageId(int lineId,long messageId);
        Task GetMessageListSent(int lineId,long startDate,long endDate, string lineNumber);
        Task GetLatestMessageByMessageCount(int lineId,long count,string lineNumber);
    }

}
