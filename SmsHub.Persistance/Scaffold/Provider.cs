using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class Provider
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Website { get; set; }

    public string? DefaultPreNumber { get; set; }

    public int BatchSize { get; set; }

    public string BaseUri { get; set; } = null!;

    public string? FallbackBaseUri { get; set; }

    public string CredentialTemplate { get; set; } = null!;

    public virtual ICollection<Line> Lines { get; set; } = new List<Line>();

    public virtual ICollection<MessageStateCategory> MessageStateCategories { get; set; } = new List<MessageStateCategory>();
}
