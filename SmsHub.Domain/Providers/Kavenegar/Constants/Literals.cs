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
        public string StatusUri { get { return $"{_baseAndKey}sms/status.json?messageid={0}"; } }
        public string StatusByMessageIdUri { get { return $"{_baseAndKey}sms/statuslocalmessageid.json?localid={0}"; } }
        public string @SelectUri { get { return $"{_baseAndKey}sms/select.json?messageid={0}"; } }
        public string SelectOutboxUri { get { return $"{_baseAndKey}sms/selectoutbox.json?startdate={0}"; } }
        public string ReceiveUri { get { return $"{_baseAndKey}sms/receive.json?linenumber={0}&isread=0"; } }
        public string CancelUri { get { return $"{_baseAndKey}sms/cancel.json?messageid={0}"; } }
        public string CountInboxUri { get { return $"{_baseAndKey}sms/countoutbox.json?startdate={0}"; } }
        public string LookupUri { get { return $"{_baseAndKey}verify/lookup.json?receptor={0}&token={1}&template={2}"; } }
        public string MakettsUri { get { return $"{_baseAndKey}call/maketts.json?receptor={0}&message={1}"; } }
        public string InfoUri { get { return $"{_baseAndKey}account/info.json"; } }
        public string ConfigUri { get { return $"{_baseAndKey}account/config.json"; } }
        public string LatestOutboxUri { get { return $"{_baseAndKey}sms/latestoutbox.json"; } }
    }
}
