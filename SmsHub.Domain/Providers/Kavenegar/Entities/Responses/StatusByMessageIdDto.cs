using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Responses
{
    public class StatusByMessageIdDto : ResponseBase
    {
        public long LocalId { get; set; }
    }
}
