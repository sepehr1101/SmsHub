using SmsHub.Domain.Providers.Asanak.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Asanak.Entities.Responses
{
    public class GetCreditDto:ResponseBase
    {
        public int Credit { get; set; }

    }
}
