namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class ReceivedMessagesDto
    {
        public int Status { get; set; }
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
