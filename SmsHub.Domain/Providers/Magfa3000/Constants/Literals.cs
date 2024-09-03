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
        public string UserName { set { UserName = value; } get { return @"User Name"; } }
        public string Domain { set { Domain = value; } get { return @"Domain"; } }
        public string Password { set { Password = value; } get { return @"Passwrod"; } }


        public Literals(string userName,string domain,string password)
        {
            UserName= userName;
            Domain = domain;
            Password= password;
        }

        public string _baseAndKey { get { return $"{BaseUrl}/{UserName}/{Domain}:{Password}/"; } }///???????

        public  string BalanceUri { get { return $"{_baseAndKey}balance.json"; } }

        public string SendUri { get { return $"{_baseAndKey}send.json?senders={0}$recipients={1}&messages={2}"; } }
        public string MidUri { get { return $"{_baseAndKey}mid.json?uid={0}"; } }
        public string StatusesUri { get { return $"{_baseAndKey}statuses.json?mid={0}"; } }
        public string MessagesUri { get { return $"{_baseAndKey}messages.json?count={0}"; } }//count nullable -> default 100


    }
}
