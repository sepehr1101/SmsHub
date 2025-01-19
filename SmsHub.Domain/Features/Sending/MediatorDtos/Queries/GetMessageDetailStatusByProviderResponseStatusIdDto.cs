namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageDetailStatusByProviderResponseStatusIdDto
    {
        public DateTime ReceiveDateTime { get; set; }
        public long MessagesDetailId { get; set; }
        public long MessageId { get; set; }

    }
}
