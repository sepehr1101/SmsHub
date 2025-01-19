namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update
{
    public record UpdateMessageDetailStatusDto
    {
        public long Id { get; set; }
        public DateTime ReceiveDateTime { get; set; }
        public long MessageId { get; set; }
        public long MessagesDetailId { get; set; }
        public int ProviderResponseStatusId { get; set; }
    }
}
