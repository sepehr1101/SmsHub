using System.Runtime.InteropServices;

namespace SmsHub.Domain.Providers.Kavenegar.Constants
{
    public class Literals
    {
        private readonly string ApiKey;
        public Literals([Optional] string apiKey)
        {
            ApiKey= apiKey;
        }
        public string BaseUrl { get { return @"https://api.kavenegar.com/v1"; } }       
        private string Sender { get { return @"20003256"; } }

        private string _baseAndKey { get { return $"{BaseUrl}/{ApiKey}/"; } }
        public string GetDateUrl { get { return $"{BaseUrl}/0/utils/getdate.json"; } }
        public string SimpleSendUri { get { return $"{_baseAndKey}sms/send.json"; } }
        public string ArraySendUri { get { return $"{_baseAndKey}sms/sendarray.json"; } }
        public string StatusUri { get { return $"{_baseAndKey}sms/status.json"; } }
        public string StatusByMessageIdUri { get { return $"{_baseAndKey}sms/statuslocalmessageid.json"; } }
        public string @SelectUri { get { return $"{_baseAndKey}sms/select.json"; } }
        public string SelectOutboxUri { get { return $"{_baseAndKey}sms/selectoutbox.json"; } }
        public string ReceiveUri { get { return $"{_baseAndKey}sms/receive.json"; } }
        public string CancelUri { get { return $"{_baseAndKey}sms/cancel.json"; } }
        public string CountInboxUri { get { return $"{_baseAndKey}sms/countoutbox.json"; } }
        public string LookupUri { get { return $"{_baseAndKey}verify/lookup.json"; } }
        public string MakettsUri { get { return $"{_baseAndKey}call/maketts.json"; } }
        public string InfoUri { get { return $"{_baseAndKey}account/info.json"; } }
        public string ConfigUri { get { return $"{_baseAndKey}account/config.json"; } }
        public string LatestOutboxUri { get { return $"{_baseAndKey}sms/latestoutbox.json"; } }
    }
}
