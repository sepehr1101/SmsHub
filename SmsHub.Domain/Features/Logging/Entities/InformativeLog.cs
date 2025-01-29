using SmsHub.Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(InformativeLog))]
    public class InformativeLog
    {
        public long Id { get; set; }
        public LogLevelEnum LogLevelId { get; set; }
        public string Section { get; set; } = null!;
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public string? UserInfo { get; set; }
        public string Ip { get; set; } = null!;
        public DateTime InsertDateTime { get; set; }
        public string ClientInfo { get; set; } = null!;

        public virtual LogLevel LogLevel { get; set; } = null!;
    }
}
