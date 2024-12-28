using SmsHub.Domain.Providers.Kavenegar.Entities.Base;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class ArraySendDto:ResponseBase
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receptor { get; set; }
        public long Date { get; set; }
        public int Cost { get; set; }

    }
}
