namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class StatusDto
    {

        public long MessageId {  get; set; }

        public StatusDto(long messageId)
        {
            if (messageId <= 0)
                throw new ArgumentOutOfRangeException(nameof(messageId));

            MessageId = messageId;
        }

        public static implicit operator StatusDto(long messageId) => new StatusDto(messageId);
    }
}
