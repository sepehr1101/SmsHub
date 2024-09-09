namespace SmsHub.Domain.Features.Entities
{
    public partial class Line
    {
        public Line()
        {
            ConsumerLines = new HashSet<ConsumerLine>();
            MessageBatches = new HashSet<MessageBatch>();
        }

        public int Id { get; set; }
        public short ProviderId { get; set; }
        public string Number { get; set; } = null!;
        public short CredentialType { get; set; }
        public string Credential { get; set; } = null!;

        public virtual Provider Provider { get; set; } = null!;
        public virtual ICollection<ConsumerLine> ConsumerLines { get; set; }
        public virtual ICollection<MessageBatch> MessageBatches { get; set; }
    }
}
