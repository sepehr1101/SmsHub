namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageDetailStatusByProviderServerIdDto
    {
        public DateTime InsertDateTime { get; set; }
        public long MessagesDetailId { get; set; }
    }
}
