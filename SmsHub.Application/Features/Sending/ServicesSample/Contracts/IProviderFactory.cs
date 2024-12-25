using SmsHub.Application.Features.Sending.ServicesSample.Implementations;

namespace SmsHub.Application.Features.Sending.ServicesSample.Contracts
{
    public interface IProviderFactory
    {
        Task Account_Balance();
        Task Status_Statuses(int messageId);
        Task Receive_Messages(int? count, string? lineNumber);
        Task Send_Send(List<SendMessageDto> message);
        Task StatusByLocalMessageId_(long localMessageId);
        Task _Mid(long userId);
        Task SelectMessage_(long  messageId);
        Task SelectOutbox_(long startDate, long endDate, string lineNumber);
        Task LatestOutbox_(long Count, string lineNumber);
        Task CountInbox_(long startDate, long endDate, string lineNumber, bool IsRead);
    }


}
