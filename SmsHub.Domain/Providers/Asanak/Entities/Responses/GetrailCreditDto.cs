using SmsHub.Domain.Providers.Asanak.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Asanak.Entities.Responses
{
    public class GetrailCreditDto : ResponseBase
    {
        public GetrialDataDto Data { get; set; }
    }
    public class GetrialDataDto//todo: change class Name
    {
        public long Credit { get; set; }
    }
}
