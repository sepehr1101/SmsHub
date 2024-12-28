namespace SmsHub.Domain.Providers.Magfa3000.Constants
{
    public static class Literals
    {
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
            foreach (var item in mids)/////todo: use ready function in common/extensions/stringExtensions
            {
                uri += $"{item},";
            }
            return uri.Substring(0, uri.Length - 1) ;
        }



        public static string MessagesUri { get { return $"{BaseUrl}messages/{0}"; } }
        public static string GetMessageUri(int count)
        {
            return $"{BaseUrl}messages/{count}";
        }


    }
}
