using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class Consumer
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string ApiKey { get; set; } = null!;

    public virtual ICollection<ConsumerLine> ConsumerLines { get; set; } = new List<ConsumerLine>();

    public virtual ICollection<ConsumerSafeIp> ConsumerSafeIps { get; set; } = new List<ConsumerSafeIp>();
}
