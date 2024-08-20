using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class DateTimeResponse
    {
        public BaseResponse Return { get; set; }

        public DateTimeDto Entries { get; set; }

        public class DateTimeDto
        {
            public string DateTime { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
            public int Hour { get; set; }
            public int Minute { get; set; }
            public int Second { get; set; }
            public int Unixtime { get; set; }
        }

    }
}
