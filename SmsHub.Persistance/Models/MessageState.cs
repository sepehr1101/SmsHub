using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class MessageState
    {
        public long Id { get; set; }
        public int MessageStateCategoryId { get; set; }
        public long MessagesDetail { get; set; }
        public DateTime InsertDateTime { get; set; }

        public virtual MessageStateCategory MessageStateCategory { get; set; } = null!;
        public virtual MessagesDetail MessagesDetailNavigation { get; set; } = null!;
    }
}
