using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class Template
{
    public int Id { get; set; }

    public string Expression { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int TemplateCategoryId { get; set; }

    public bool IsActive { get; set; }

    public string Parameters { get; set; } = null!;

    public int MinCredit { get; set; }

    public virtual ICollection<Config> Configs { get; set; } = new List<Config>();

    public virtual TemplateCategory TemplateCategory { get; set; } = null!;
}
