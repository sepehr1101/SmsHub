namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public partial class LookupDto
    {
            public int MessageId { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
            public string Sender { get; set; }
            public string Receptor { get; set; }
            public int Date { get; set; }
            public int Cost { get; set; }
        }

    }
