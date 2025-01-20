using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Sending.Entities
{
    public class MessageDetailStatus
    {
        public long  Id { get; set; }
        public DateTime InsertDateTime {  get; set; } 
        public long ProviderServerId {  get; set; }
        public long MessagesDetailId {  get; set; }

        public virtual MessageDetail MessagesDetail { get; set; }

    }
}
