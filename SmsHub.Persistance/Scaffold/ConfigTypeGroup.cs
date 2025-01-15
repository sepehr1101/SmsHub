using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class ConfigTypeGroup
{
    public int Id { get; set; }

    public short ConfigTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CcSend> CcSends { get; set; } = new List<CcSend>();

    public virtual ConfigType ConfigType { get; set; } = null!;

    public virtual ICollection<Config> Configs { get; set; } = new List<Config>();

    public virtual ICollection<DisallowedPhrase> DisallowedPhrases { get; set; } = new List<DisallowedPhrase>();

    public virtual ICollection<PermittedTime> PermittedTimes { get; set; } = new List<PermittedTime>();
}
