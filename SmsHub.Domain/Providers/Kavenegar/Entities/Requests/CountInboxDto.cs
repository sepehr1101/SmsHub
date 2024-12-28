namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class CountInboxDto
    {
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public string LineNumber {  get; set; }
        public int IsRead {  get; set; }


    }
}
