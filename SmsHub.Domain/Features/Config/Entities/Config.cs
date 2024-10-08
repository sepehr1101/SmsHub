using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(Config))]
    public class Config
    {
        public int Id { get; set; }
        public int ConfigTypeGroupId { get; set; }
        public int TemplateId { get; set; }

        public virtual ConfigTypeGroup ConfigTypeGroup { get; set; } = null!;
        public virtual Template Template { get; set; } = null!;
    }
}
