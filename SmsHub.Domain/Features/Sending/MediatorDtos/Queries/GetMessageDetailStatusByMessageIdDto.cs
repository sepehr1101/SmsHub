namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageDetailStatusByMessageIdDto
    {
        public DateTime ReceiveDateTime { get; set; }
        public long MessagesDetailId { get; set; }
        public int ProviderResponseStatusId { get; set; }
    }
}
