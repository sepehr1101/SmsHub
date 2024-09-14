using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(LogLevel))]
    public class LogLevel
    {
        public LogLevel()
        {
            InformativeLogs = new HashSet<InformativeLog>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;

        public virtual ICollection<InformativeLog> InformativeLogs { get; set; }
    }
}
