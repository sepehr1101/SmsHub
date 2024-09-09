using SmsHub.Domain.Features.Consumer.Entities;

namespace SmsHub.Domain.Entities
{
    public partial class ConsumerLine
    {
        public int Id { get; set; }
        public int ConsumerId { get; set; }
        public int LineId { get; set; }

        public virtual Consumer Consumer { get; set; } = null!;
        public virtual Line Line { get; set; } = null!;
    }
}
