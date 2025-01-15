using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class MessageBatch
{
    public int Id { get; set; }

    public int HolderSize { get; set; }

    public int AllSize { get; set; }

    public DateTime InsertDateTime { get; set; }

    public int LineId { get; set; }

    public virtual Line Line { get; set; } = null!;

    public virtual ICollection<MessagesHolder> MessagesHolders { get; set; } = new List<MessagesHolder>();
}
