using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class TemplateCategory
    {
        public TemplateCategory()
        {
            Templates = new HashSet<Template>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Template> Templates { get; set; }
    }
}
