using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class CancelDto
    {
        public long MessageId { get; set; }
        public int Status { get; set; } 
        public string StatusText{ get; set; }
    }
}
