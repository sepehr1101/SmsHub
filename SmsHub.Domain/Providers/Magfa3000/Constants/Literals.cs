using SmsHub.Common.Extensions;

namespace SmsHub.Domain.Providers.Magfa3000.Constants
{
    public static class Literals
    {        
        //public static string BaseUrl { get { return @"http://10.7.217.99/api/http/sms/v2"; } }
        public static string BaseUrl { get { return @"https://sms.magfa.com/api/http/sms/v2/"; } }

        public static string BalanceUri { get { return $"{BaseUrl}balance"; } }

        public static string SendUri { get { return $"{BaseUrl}send"; } }//parameters in body



        public static string MidUri { get { return $"{BaseUrl}mid/{0}"; } }
        public static string GetMidUri(long uid)
        {
            return $"{BaseUrl}mid/{uid}";
        }


        public static string StatusesUri { get { return $"{BaseUrl}statuses/{0}"; } }

        public static string GettatusesUri(long mid)
        {
            return $"{BaseUrl}statuses/{mid}";
        }
        public static string GettatusesUri(ICollection<long> mids)
        {
            var uri = $"{BaseUrl}statuses/";
            var data = mids.AppendString(",");
            return uri + data;          
        }



        public static string MessagesUri { get { return $"{BaseUrl}messages"; } }
        
    }
}
