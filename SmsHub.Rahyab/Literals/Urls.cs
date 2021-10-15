namespace SmsHub.Rahyab.Literals
{
    public static class Urls
    {
        public static string BaseUrl { get { return @"https://api.rahyab.ir"; } }
        public static string AuthUrl { get { return BaseUrl + @"/api/Auth/getToken"; } }
        public static string CreditUrl { get { return BaseUrl + @"/api/v1/GetRemainCredit"; } }
        public static string PeerToPeerUrl { get { return BaseUrl + @"/api/v1/SendSMS_LikeToLike"; } }
        public static string SingleUrl { get { return BaseUrl + @"/api/v1/SendSMS_Single"; } }
        public static string BatchUrl { get { return BaseUrl + @"/api/v1/SendSMS_Batch"; } }
        public static string DeliveryUrl { get { return BaseUrl + @"/api/v1/StatusSMS"; } }
    }
}
