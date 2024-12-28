namespace SmsHub.Domain.Providers.Asanak.Entities.RequestsDto
{
    public class SendSmsDto
    {
        public string Source {  get; set; }
        public ICollection<string> Destination { get; set; }
        public string Message { get; set; }
        public int Send_To_BlackList {  get; set; }

    }
}
