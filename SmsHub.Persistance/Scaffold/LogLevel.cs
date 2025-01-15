using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class LogLevel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Css { get; set; } = null!;

    public virtual ICollection<InformativeLog> InformativeLogs { get; set; } = new List<InformativeLog>();
}
