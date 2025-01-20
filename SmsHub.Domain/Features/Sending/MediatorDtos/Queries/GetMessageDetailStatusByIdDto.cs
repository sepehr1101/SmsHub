namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public class GetMessageDetailStatusByIdDto
    {
        public DateTime ReceiveDateTime { get; set; }
        public long MessageId { get; set; }
        public long MessagesDetailId { get; set; }
        public int ProviderResponseStatusId { get; set; }

    }
}
