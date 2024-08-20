using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    //Latestoutbox, countOutbox
    public class OutBoxDto
    {
        public long? PageSize { get; set; }
        public string? Sender{ get; set; }
    }
}
