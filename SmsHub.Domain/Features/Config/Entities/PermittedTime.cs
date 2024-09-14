namespace SmsHub.Domain.Features.Entities
{
    public class PermittedTime
    {
        public int Id { get; set; }
        public int PermittedTimeGroupId { get; set; }
        public string FromTime { get; set; } = null!;
        public string ToTime { get; set; } = null!;

        public virtual PermittedTimeGroup PermittedTimeGroup { get; set; } = null!;
    }
}
