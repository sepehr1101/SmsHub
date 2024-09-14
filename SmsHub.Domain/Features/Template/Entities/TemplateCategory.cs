using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(TemplateCategory))]
    public class TemplateCategory
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
