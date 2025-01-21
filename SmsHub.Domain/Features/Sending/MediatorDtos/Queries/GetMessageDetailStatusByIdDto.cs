namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public class GetMessageDetailStatusByIdDto
    {
        public DateTime InsertDateTime { get; set; }
        public long ProviderServerId { get; set; }
        public long MessagesDetailId { get; set; }
        public Guid MessagesHolderId { get; set; }
        public int ProviderDeliveryStatusId { get; set; }

    }
}
