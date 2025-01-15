using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class DisallowedPhrase
{
    public int Id { get; set; }

    public int ConfigTypeGroupId { get; set; }

    public string Phrase { get; set; } = null!;

    public virtual ConfigTypeGroup ConfigTypeGroup { get; set; } = null!;
}
