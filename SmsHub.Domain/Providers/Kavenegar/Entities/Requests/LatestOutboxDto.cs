using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class LatestOutboxDto
    {
        public long  PageSize { get; set; }
        public string Sender {  get; set; }
    }
}
