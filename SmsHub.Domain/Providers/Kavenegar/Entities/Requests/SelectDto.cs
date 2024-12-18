using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class SelectDto
    {
        public long MessageId {  get; set; }

        public SelectDto(long messageId)
        {
            if(messageId <= 0)
                throw new ArgumentOutOfRangeException(nameof(messageId));
            MessageId = messageId;
        }

        public static implicit operator SelectDto(long messageId)=>new SelectDto(messageId);
    }
}
