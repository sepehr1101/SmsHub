using System.Security.Cryptography;

namespace SmsHub.Domain.Providers.Magfa3000.Constants
{
    public static class Literals
    {
        public static string BaseUrl { get { return @"https://sms.magfa.com/api/http/sms/v2/"; } }


        //public  string BalanceUri { get { return $"{BaseUrl}balance.json"; } }
        public static string BalanceUri { get { return $"{BaseUrl}balance"; } }

        // public string SendUri { get { return $"{BaseUrl}send.json?senders={0}$recipients={1}&messages={2}"; } }
        public static string SendUri { get { return $"{BaseUrl}send"; } }//parameters in body



        //public string MidUri { get { return $"{BaseUrl}mid.json?uid={0}"; } }
        public static string MidUri { get { return $"{BaseUrl}mid/{0}"; } }
        public static string GetMidUri(long uid)
        {
            return $"{BaseUrl}mid/{uid}";
        }

        //public string StatusesUri { get { return $"{BaseUrl}statuses.json?mid={0}"; } }
        public static string StatusesUri { get { return $"{BaseUrl}statuses/{0}"; } }

        public static string GettatusesUri(long mid)
        {
            return $"{BaseUrl}statuses/{mid}";
        }
        public static string GettatusesUri(ICollection<long> mids)
        {
            var uri = $"{BaseUrl}statuses/";
            foreach (var item in mids)///////
            {
                uri += $"{item},";
            }
            return uri.Substring(0, uri.Length - 1) ;
        }



        //public string MessagesUri { get { return $"{BaseUrl}messages.json?count={0}"; } }//count nullable -> default 100
        public static string MessagesUri { get { return $"{BaseUrl}messages/{0}"; } }
        public static string GetMessageUri(int count)
        {
            return $"{BaseUrl}messages/{count}";
        }


    }
}
