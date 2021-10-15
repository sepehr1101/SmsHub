using SmsHub.Rahyab.Dtos.Base;
using System.Collections.Generic;

namespace SmsHub.Rahyab.Dtos.Input
{
    public class SendInputBatch: UserPassCompanyNumber
    {
        public string Message { get; set; }
        public ICollection<string> DestinationAddress { get; set; }
    }
}
