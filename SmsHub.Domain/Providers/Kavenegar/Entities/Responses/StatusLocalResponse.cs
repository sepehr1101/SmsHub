using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class StatusLocalResponse
    {
        public BaseResponse Return { get; set; }
        public StatusLocalDto[] Entries { get; set; }
    }
}
