namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class ReceiveDto
    {
        public long MessageId { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receptor { get; set; }
        public long Date { get; set; }

    }
}
