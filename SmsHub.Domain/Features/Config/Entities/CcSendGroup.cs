namespace SmsHub.Domain.Features.Entities
{
    public class CcSendGroup
    {
        public CcSendGroup()
        {
            CcSends = new HashSet<CcSend>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<CcSend> CcSends { get; set; }
    }
}
