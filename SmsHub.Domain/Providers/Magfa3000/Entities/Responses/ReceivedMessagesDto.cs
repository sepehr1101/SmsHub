using SmsHub.Domain.Providers.Magfa3000.Entities.Base;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class ReceivedMessagesDto:ResponseBase
    {
        public ICollection<ResponseReceivedMessagesDto> Messages { get; set; }
    }

    public class ResponseReceivedMessagesDto
    {
        public string Body { get; set; }
        public string SenderNubmer { get; set; }
        public string RecipientNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
