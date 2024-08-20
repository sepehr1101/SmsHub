using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class StatusResponse
    {
        public BaseResponse Return { get; set; }
        public StatusDto[] Entries { get; set; }
    }
}
