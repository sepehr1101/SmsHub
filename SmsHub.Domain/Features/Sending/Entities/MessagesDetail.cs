using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(MessagesDetail))]
    public class MessagesDetail
    {
        public MessagesDetail()
        {
            MessageStates = new HashSet<MessageState>();
        }

        public long Id { get; set; }
        public Guid MessagesHolderId { get; set; }
        public string Receptor { get; set; } = null!;
        public long ProviderResult { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Text { get; set; } = null!;
        public short SmsCount { get; set; }

        public virtual MessagesHolder MessagesHolder { get; set; } = null!;
        public virtual ICollection<MessageState> MessageStates { get; set; }
    }
}
