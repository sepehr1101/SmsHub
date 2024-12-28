namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class SelectOutboxDto
    {
        public long StartDate {  get; set; }
        public long EndDate { get; set; } = 0;
        public string Sender {  get; set; }
    }
}
