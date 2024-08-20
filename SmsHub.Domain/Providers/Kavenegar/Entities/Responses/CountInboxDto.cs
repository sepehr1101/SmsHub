using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class CountInboxDto
    {
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public long SumCount { get; set; }


    }
}
