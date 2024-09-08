using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class LogLevel
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
