using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class Template
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int TemplateCategoryId { get; set; }
        public bool IsActive { get; set; }
        public string Parameters { get; set; } = null!;

        public virtual TemplateCategory TemplateCategory { get; set; } = null!;
    }
}
