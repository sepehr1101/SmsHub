using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class Config
{
    public int Id { get; set; }

    public int ConfigTypeGroupId { get; set; }

    public int TemplateId { get; set; }

    public virtual ConfigTypeGroup ConfigTypeGroup { get; set; } = null!;

    public virtual Template Template { get; set; } = null!;
}
