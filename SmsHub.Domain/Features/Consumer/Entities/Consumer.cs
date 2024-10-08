﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(Consumer))]
    public class Consumer
    {
        public Consumer()
        {
            ConsumerLines = new HashSet<ConsumerLine>();
            ConsumerSafeIps = new HashSet<ConsumerSafeIp>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } 
        public string ApiKey { get; set; } = null!;

        public virtual ICollection<ConsumerLine> ConsumerLines { get; set; }
        public virtual ICollection<ConsumerSafeIp> ConsumerSafeIps { get; set; }
    }
}
