using SmsHub.Domain.Features.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Sending.Entities
{
    [Table(nameof(MessageDetailStatus))]
    public class MessageDetailStatus
    {
        public long  Id { get; set; }
        public DateTime InsertDateTime {  get; set; } 
        public long ProviderServerId {  get; set; }
        public long MessagesDetailId {  get; set; }
        public Guid MessagesHolderId {  get; set; } 
        public int ProviderDeliveryStatusId {  get; set; }
        public int? ProviderResponseStatusId {  get; set; }

        public virtual MessageDetail MessagesDetail { get; set; }
        public virtual MessagesHolder MessagesHolder { get; set; }
        public virtual ProviderDeliveryStatus ProviderDeliveryStatus { get; set; }
        public virtual ProviderResponseStatus ProviderResponseStatus { get; set; }


    }
}
