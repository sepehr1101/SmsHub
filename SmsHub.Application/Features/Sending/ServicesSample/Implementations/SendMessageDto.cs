namespace SmsHub.Application.Features.Sending.ServicesSample.Implementations
{
    public class SendMessageDto
    {
        public string Message { get; set; }
        public string Receptor { get; set; }
        public string Sender { get; set; }
        public long Date { get; set; }
        public long? localMessageId { get; set; }
        public long? UserId{ get; set; }
    }
}
