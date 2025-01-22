using SmsHub.Domain.Features.Sending.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(MessagesHolder))]
    public class MessagesHolder
    {
        public MessagesHolder()
        {
            MessagesDetails = new HashSet<MessageDetail>();
        }

        public Guid Id { get; set; }
        public int MessageBatchId { get; set; }
        public DateTime InsertDateTime { get; set; }
        public int RetryCount { get; set; }
        public int DetailsSize { get; set; }
        public bool SendDone { get; set; }

        public virtual MessageBatch MessageBatch { get; set; } = null!;
        public virtual ICollection<MessageDetail> MessagesDetails { get; set; }
        public virtual ICollection<MessageDetailStatus> MessageDetailStatuses { get; set; }
    }
}
