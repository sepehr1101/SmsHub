using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class Received
{
    public long Id { get; set; }

    public long? MessageId { get; set; }

    public string MessageText { get; set; } = null!;

    public string Sender { get; set; } = null!;

    public string Receptor { get; set; } = null!;

    public DateTime ReceiveDateTime { get; set; }

    public DateTime InsertDateTime { get; set; }
}
