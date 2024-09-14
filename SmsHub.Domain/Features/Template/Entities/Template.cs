using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(Template))]
    public class Template
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int TemplateCategoryId { get; set; }
        public bool IsActive { get; set; }
        public string Parameters { get; set; } = null!;
        public int MinCredit { get; set; }

        public virtual TemplateCategory TemplateCategory { get; set; } = null!;
    }
}
