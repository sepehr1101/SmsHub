using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Asanak.Entities.Requests
{
    public class MsgStatusDto
    {
        public ICollection<string> MsgId {  get; set; }
    }
}
