namespace SmsHub.Core.Dtos
{
    public class MobileText
    {
        public string Mobile { get; set; }
        public string Text { get; set; }
        public string MessageId { get; set; }
        public MobileText()
        {
            MessageId = string.Empty;
        }
    }
}
