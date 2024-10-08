using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(ConsumerLine))]
    public class ConsumerLine
    {
        public int Id { get; set; }
        public int ConsumerId { get; set; }
        public int LineId { get; set; }

        public virtual Consumer Consumer { get; set; } = null!;
        public virtual Line Line { get; set; } = null!;
    }
}
