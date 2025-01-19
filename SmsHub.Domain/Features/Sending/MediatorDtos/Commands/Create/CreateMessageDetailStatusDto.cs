namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateMessageDetailStatusDto
    {
        public DateTime ReceiveDateTime { get; set; }
        public long MessageId { get; set; }
        public long MessagesDetailId { get; set; }
        public int ProviderResponseStatusId { get; set; }

    }
}
