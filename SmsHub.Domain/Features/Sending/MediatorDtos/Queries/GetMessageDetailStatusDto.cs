namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public class GetMessageDetailStatusDto
    {
        public long Id { get; set; }
        public DateTime ReceiveDateTime { get; set; }
        public long MessageId { get; set; }
        public long MessagesDetailId { get; set; }
        public int ProviderResponseStatusId { get; set; }

    }
}
