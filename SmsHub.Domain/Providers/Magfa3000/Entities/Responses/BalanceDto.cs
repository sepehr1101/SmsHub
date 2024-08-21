using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class BalanceDto
    {
        public int Status { get; set; }
        public long Balance { get; set; }
    }
}
