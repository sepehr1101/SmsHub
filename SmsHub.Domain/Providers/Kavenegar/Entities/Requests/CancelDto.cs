namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class CancelDto
    {
        public long MessageId {  get; set; }
        public CancelDto(long messageId)
        {
            if (messageId <= 0)
                throw new ArgumentOutOfRangeException(nameof(messageId));

            MessageId = messageId;
        }
        public static implicit operator CancelDto(long messageId) => new CancelDto(messageId);
    }
}
