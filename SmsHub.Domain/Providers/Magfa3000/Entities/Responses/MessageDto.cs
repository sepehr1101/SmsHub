using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class MessageDto
    {
        public int Status { get; set; }
        public ICollection<MessageMessagesDto> Messages { get; set; }
    }

    public class MessageMessagesDto//todo : change class Name
    {
        public string Body { get; set; }
        public string SenderNubmer { get; set; }
        public string RecipientNumber { get; set; }
        public string Date { get; set; }
    }
}
