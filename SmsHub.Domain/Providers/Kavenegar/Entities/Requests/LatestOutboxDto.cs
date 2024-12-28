namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class LatestOutboxDto
    {
        public long  PageSize { get; set; }
        public string Sender {  get; set; }
    }
}
