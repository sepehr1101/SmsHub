using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Lines = new HashSet<Line>();
            MessageStateCategories = new HashSet<MessageStateCategory>();
        }

        public short Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Website { get; set; }
        public string? DefaultPreNumber { get; set; }
        public int BatchSize { get; set; }
        public string BaseUri { get; set; } = null!;
        public string FallbackBaseUri { get; set; } = null!;

        public virtual ICollection<Line> Lines { get; set; }
        public virtual ICollection<MessageStateCategory> MessageStateCategories { get; set; }
    }
}
