using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class ReceiveDto
    {
        public long MessageId { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receptor { get; set; }
        public long Date { get; set; }

    }
}
