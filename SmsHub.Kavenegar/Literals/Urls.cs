using System;
using System.Collections.Generic;
using System.Text;

namespace SmsHub.Kavenegar.Literals
{
    public static class Urls
    {
        private static string apiKey = @"api_key";
        public static string BaseUrl { get { return $"https://api.kavenegar.com/v1/{apiKey}"; } }
        public static string SendBatchUrl { get { return BaseUrl+@"/sms/sendarray.json"; } }

    }
}
