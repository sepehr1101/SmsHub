using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class TemplateCategory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Template> Templates { get; set; } = new List<Template>();
}
