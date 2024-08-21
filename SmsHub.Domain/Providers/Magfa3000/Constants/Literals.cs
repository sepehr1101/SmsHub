using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Magfa3000.Constants
{
    public class Literals
    {
        public string BaseUrl { get { return @"https://sms.magfa.com/api/http/sms/v2"; } }
        public string UserName { get { return @"123456464"; } }
        public string Domain { get { return @"20003256"; } }
        public string Password { get { return @"20003256"; } }



        private string _baseAndKey { get { return $"{BaseUrl}/{UserName}/{Domain}:{Password}/"; } }///???????

        private string BalanceUri { get { return $"{_baseAndKey}balance.json"; } }
        private string SendUri { get { return $"{_baseAndKey}send.json?senders={0}$recipients={1}&messages={2}"; } }
        private string MidUri { get { return $"{_baseAndKey}mid.json?uid={0}"; } }
        private string StatusesUri { get { return $"{_baseAndKey}statuses.json?mid={0}"; } }
        private string MessagesUri { get { return $"{_baseAndKey}messages.json?count={0}"; } }//count nullable -> default 100


    }
}
