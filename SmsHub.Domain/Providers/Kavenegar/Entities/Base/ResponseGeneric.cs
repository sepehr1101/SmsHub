using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Base
{

    public class ResponseGeneric<T>
    {
        public Return @Return { get; set; }

        public T Entries { get; set; }

    }
    public class Return
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
