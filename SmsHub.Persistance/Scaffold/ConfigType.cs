using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class ConfigType
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ConfigTypeGroup> ConfigTypeGroups { get; set; } = new List<ConfigTypeGroup>();
}
