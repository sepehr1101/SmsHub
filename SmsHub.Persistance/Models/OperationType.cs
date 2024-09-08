using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class OperationType
    {
        public OperationType()
        {
            DeepLogs = new HashSet<DeepLog>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;

        public virtual ICollection<DeepLog> DeepLogs { get; set; }
    }
}
