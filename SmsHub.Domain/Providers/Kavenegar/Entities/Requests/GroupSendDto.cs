using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class GroupSendDto
    {
        public string[] Receptor;
        public string[] Message;
        public string[] Sender;

        public string? date;
        public int[] Type;
        public long[] LocalMessageIds;
        public byte? Hide;
    }
}
