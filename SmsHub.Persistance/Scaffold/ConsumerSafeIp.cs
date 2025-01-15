using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class ConsumerSafeIp
{
    public int Id { get; set; }

    public int ConsumerId { get; set; }

    public string FromIp { get; set; } = null!;

    public string ToIp { get; set; } = null!;

    public bool IsV6 { get; set; }

    public virtual Consumer Consumer { get; set; } = null!;
}
