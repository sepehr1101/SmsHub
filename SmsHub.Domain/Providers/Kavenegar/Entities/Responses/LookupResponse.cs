using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public partial class LookupDto
    {

        public class Rootobject
        {
            public BaseResponse Return { get; set; }
            public LookupDto[] entries { get; set; }
        }

    }
}
