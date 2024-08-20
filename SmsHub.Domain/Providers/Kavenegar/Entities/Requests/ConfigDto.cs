using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class ConfigDto
    {
        public string  ApiLogs { get; set; }
        public string DailyReport { get; set; }
        public string DebugMode { get; set; }
        public string  DefaultSender { get; set; }
        public int MinCreditAlarm { get; set; }
        public string ResendFailed { get; set; }
    }
}
