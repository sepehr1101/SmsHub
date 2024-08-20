using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public  class TTSResponse
    {
        public BaseResponse Return { get; set; }
        public SendDto[] Entries { get; set; }

    }
}
