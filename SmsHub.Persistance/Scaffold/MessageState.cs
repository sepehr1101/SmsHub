using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class MessageState
{
    public long Id { get; set; }

    public int MessageStateCategoryId { get; set; }

    public long MessagesDetailId { get; set; }

    public DateTime InsertDateTime { get; set; }

    public virtual MessageStateCategory MessageStateCategory { get; set; } = null!;

    public virtual MessagesDetail MessagesDetail { get; set; } = null!;
}
