using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Asanak.Entities.Base
{
    public class ResponseBase
    {
        public MetaDto Meta { get; set; }

    }
    public class MetaDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
