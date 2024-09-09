namespace SmsHub.Domain.Features.Entities
{
    public partial class InformativeLog
    {
        public long Id { get; set; }
        public int LogLevelId { get; set; }
        public string Section { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? UserId { get; set; }
        public string? UserInfo { get; set; }
        public string Ip { get; set; } = null!;
        public DateTime InsertDateTime { get; set; }
        public string ClientInfo { get; set; } = null!;

        public virtual LogLevel LogLevel { get; set; } = null!;
    }
}
