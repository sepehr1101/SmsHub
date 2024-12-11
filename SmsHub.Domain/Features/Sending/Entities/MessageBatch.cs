using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(MessageBatch))]   
    public class MessageBatch
    {
        public MessageBatch()
        {
            MessagesHolders = new HashSet<MessagesHolder>();
        }

        public int Id { get; set; }
        public int HolderSize { get; set; }
        public int AllSize { get; set; }
        public DateTime InsertDateTime { get; set; }
        public int LineId { get; set; }

        public virtual Line Line { get; set; } = null!;
        public virtual ICollection<MessagesHolder> MessagesHolders { get; set; }
    }
}
