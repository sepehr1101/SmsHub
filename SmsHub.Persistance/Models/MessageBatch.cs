using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class MessageBatch
    {
        public MessageBatch()
        {
            MessagesHolders = new HashSet<MessagesHolder>();
        }

        public int Id { get; set; }
        public int HolerSize { get; set; }
        public int AllSize { get; set; }
        public DateTime InsertDateTime { get; set; }
        public int LineId { get; set; }

        public virtual Line Line { get; set; } = null!;
        public virtual ICollection<MessagesHolder> MessagesHolders { get; set; }
    }
}
