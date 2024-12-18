namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class StatusByMessageIdDto
    {

        public long LocalId { get; set; }

        public StatusByMessageIdDto(long localId)
        {
            if (localId <= 0)
                throw new ArgumentOutOfRangeException(nameof(localId));

            LocalId = localId;
        }
        public static implicit operator StatusByMessageIdDto(long localId) => new StatusByMessageIdDto(localId);
    }
}
