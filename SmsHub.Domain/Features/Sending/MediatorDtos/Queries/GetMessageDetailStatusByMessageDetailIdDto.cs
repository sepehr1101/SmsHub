namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageDetailStatusByMessageDetailIdDto
    {
        public DateTime InsertDateTime { get; set; }
        public long ProviderServerId { get; set; }
        public Guid MessagesHolderId { get; set; }
        public int ProviderDeliveryStatusId { get; set; }
    }
}
