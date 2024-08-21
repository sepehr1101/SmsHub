using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Asanak.Entities.RequestsDto
{
    public class SendSmsDto
    {
        public string Source {  get; set; }
        public ICollection<string> Destination { get; set; }
        public string Message { get; set; }
        public int Send_To_BlackList {  get; set; }

    }
}
