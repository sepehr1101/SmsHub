namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class SendDto
    {
        public int Status { get; set; }
        public ICollection<SendMessageDto> Message {  get; set; }
    }
    public class SendMessageDto//todo : change class Name
    {
        public int Status { get; set; }
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public int Parts { get; set; }
        public float Tariff { get; set; }
        public string Alphabet { get; set; }
        public string Recipient { get; set; }
    }
}

