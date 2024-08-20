using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    //Select, SelectOutbox, LatestOutBox
    public class SelectResponse
    {
        public BaseResponse Return { get; set; }
        public SelectDto[] Entries { get; set; }
    }
}
