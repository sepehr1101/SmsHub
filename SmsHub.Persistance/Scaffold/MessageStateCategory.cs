using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class MessageStateCategory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public short ProviderId { get; set; }

    public bool IsError { get; set; }

    public string Css { get; set; } = null!;

    public virtual ICollection<MessageState> MessageStates { get; set; } = new List<MessageState>();

    public virtual Provider Provider { get; set; } = null!;
}
