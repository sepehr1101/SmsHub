namespace SmsHub.Domain.Features.Entities
{
    public class CcSend
    {
        public int Id { get; set; }
        public int CcSendGroupId { get; set; }
        public string Mobile { get; set; } = null!;

        public virtual CcSendGroup CcSendGroup { get; set; } = null!;
    }
}
