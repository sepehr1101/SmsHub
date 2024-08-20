using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class CancelResponse
    {
        public BaseResponse Return { get; set; }
        public CancelDto[] Entries { get; set; }
    }
}
