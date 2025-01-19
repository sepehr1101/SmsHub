namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageDetailStatusByMessageDetailIdDto
    {
        public DateTime ReceiveDateTime { get; set; }
        public long MessageId { get; set; }
        public int ProviderResponseStatusId { get; set; }
    }
}
