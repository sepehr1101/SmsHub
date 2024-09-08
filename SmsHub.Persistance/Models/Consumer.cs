using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class Consumer
    {
        public Consumer()
        {
            ConsumerLines = new HashSet<ConsumerLine>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ApiKey { get; set; } = null!;

        public virtual ICollection<ConsumerLine> ConsumerLines { get; set; }
    }
}
