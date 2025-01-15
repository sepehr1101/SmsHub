using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class MessagesHolder
{
    public Guid Id { get; set; }

    public int MessageBatchId { get; set; }

    public DateTime InsertDateTime { get; set; }

    public int RetryCount { get; set; }

    public int DetailsSize { get; set; }

    public bool SendDone { get; set; }

    public virtual MessageBatch MessageBatch { get; set; } = null!;

    public virtual ICollection<MessagesDetail> MessagesDetails { get; set; } = new List<MessagesDetail>();
}
