using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class CountInboxDto
    {
        public long StartDate { get; set; }
        public long? EndDate { get; set; }
        public string? LineNumber { get; set; }
        public int? IsRead { get; set; }
    }
}
