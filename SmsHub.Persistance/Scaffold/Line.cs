using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class Line
{
    public int Id { get; set; }

    public short ProviderId { get; set; }

    public string Number { get; set; } = null!;

    public string Credential { get; set; } = null!;

    public virtual ICollection<ConsumerLine> ConsumerLines { get; set; } = new List<ConsumerLine>();

    public virtual ICollection<MessageBatch> MessageBatches { get; set; } = new List<MessageBatch>();

    public virtual Provider Provider { get; set; } = null!;
}
