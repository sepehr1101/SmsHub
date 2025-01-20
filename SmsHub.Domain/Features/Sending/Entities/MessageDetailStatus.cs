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

        public virtual MessageDetail MessagesDetail { get; set; }

    }
}
