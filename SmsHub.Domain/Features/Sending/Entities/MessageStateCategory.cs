using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(MessageStateCategory))]
    public class MessageStateCategory
    {
        public MessageStateCategory()
        {
            MessageStates = new HashSet<MessageState>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public short Provider { get; set; }
        public bool IsError { get; set; }
        public string Css { get; set; } = null!;

        public virtual Provider ProviderNavigation { get; set; } = null!;
        public virtual ICollection<MessageState> MessageStates { get; set; }
    }
}
