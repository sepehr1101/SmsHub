using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class MessagesDetail
{
    public long Id { get; set; }

    public Guid MessagesHolderId { get; set; }

    public string Receptor { get; set; } = null!;

    public long ProviderResult { get; set; }

    public DateTime SendDateTime { get; set; }

    public string Text { get; set; } = null!;

    public short SmsCount { get; set; }

    public virtual ICollection<MessageState> MessageStates { get; set; } = new List<MessageState>();

    public virtual MessagesHolder MessagesHolder { get; set; } = null!;
}
