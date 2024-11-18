using SmsHub.Domain.Constants;
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
        public ProviderEnum ProviderId { get; set; }
        public bool IsError { get; set; }
        public string Css { get; set; } = null!;

        public virtual Provider Providers { get; set; } = null!;
        public virtual ICollection<MessageState> MessageStates { get; set; }
    }
}
