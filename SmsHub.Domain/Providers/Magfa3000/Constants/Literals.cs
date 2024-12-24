namespace SmsHub.Domain.Providers.Magfa3000.Constants
{
    public class Literals
    {
        public string BaseUrl { get { return @"https://sms.magfa.com/api/http/sms/v2/"; } }

        public Literals()
        {

        }

        //public  string BalanceUri { get { return $"{BaseUrl}balance.json"; } }
        public  string BalanceUri { get { return $"{BaseUrl}balance"; } }

       // public string SendUri { get { return $"{BaseUrl}send.json?senders={0}$recipients={1}&messages={2}"; } }
        public string SendUri { get { return $"{BaseUrl}send"; } }//parameters in body
       
        
        
        //public string MidUri { get { return $"{BaseUrl}mid.json?uid={0}"; } }
        public string MidUri { get { return $"{BaseUrl}mid/{0}"; } }
      
        //public string StatusesUri { get { return $"{BaseUrl}statuses.json?mid={0}"; } }
        public string StatusesUri { get { return $"{BaseUrl}statuses/{0}"; } }
      
        
        
        
        //public string MessagesUri { get { return $"{BaseUrl}messages.json?count={0}"; } }//count nullable -> default 100
        public string MessagesUri { get { return $"{BaseUrl}messages/{0}"; } }//this uri format is true


    }
}
