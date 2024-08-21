using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class ArraySendDto
    {
        public ICollection<string> Receptor { get; set; }
        public ICollection<string> Sender { get; set; }
        public ICollection<string>  Message { get; set; }
        public long Date { get; set; }
        public ICollection<int> Type { get; set; }
        public ICollection<long> LocalMessageIds { get; set; }
        public short Hide { get; set; }

    }
}
