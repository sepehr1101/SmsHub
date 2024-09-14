namespace SmsHub.Domain.Features.Entities
{
    public class PermittedTimeGroup
    {
        public PermittedTimeGroup()
        {
            PermittedTimes = new HashSet<PermittedTime>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<PermittedTime> PermittedTimes { get; set; }
    }
}
