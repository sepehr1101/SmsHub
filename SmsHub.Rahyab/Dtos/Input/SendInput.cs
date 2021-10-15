using System.Collections.Generic;
using SmsHub.Rahyab.Dtos.Base;

namespace SmsHub.Rahyab.Dtos.Input
{
    public class SendInput: UserPassCompanyNumber
    {
        public ICollection<ListLikeToLikeMessage> ListLikeToLikeMessage { get; set; }
    }
}
