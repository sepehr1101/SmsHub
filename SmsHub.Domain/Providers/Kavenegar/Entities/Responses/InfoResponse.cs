using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class InfoResponse
    {
        public long RemainCredit { get; set; }
        public string ExpireDate {  get; set; }
        public string Type { get; set; }
    }
}
