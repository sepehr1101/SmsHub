using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Requests
{
    public class SendDto
    {
        public ICollection<string> Sender { get; set; }
        public ICollection<string> Recipients { get; set; }
        public ICollection<string> Messages { get; set; }
        public int Encodings { get; set; }
        public ICollection<long> UIds { get; set; }
       // public string Udhs {  get; set; }// todo: we do not need
    }
}
