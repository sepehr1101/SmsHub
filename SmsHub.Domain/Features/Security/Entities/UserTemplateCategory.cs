using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Security.Entities
{
    public class UserTemplateCategory
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public int TemplateCategoryId { get; set; }

        public virtual User User { get; set; }
        public virtual TemplateCategory TemplateCategory { get; set; }
    }
}
