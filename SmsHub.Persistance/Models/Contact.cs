using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
