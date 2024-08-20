namespace SmsHub.Domain.Providers.Kavenegar.Constants
{
    public class Literals
    {
        public string BaseUrl { get { return @"https://api.kavenegar.com/v1"; } }
        public string ApiKey { get { return @"123456464"; } }
        public string Sender { get { return @"20003256"; } }
        private string _baseAndKey { get { return $"{BaseUrl}/{ApiKey}/"; } }
        public string SimpleSendUri { get { return $"{_baseAndKey}sms/send.json?receptor={0}&sender={1}&message={2}"; } }
        public string ArraySendUri { get { return $"{_baseAndKey}sms/sendarray.json"; } }
        public string Status { get { return $"{_baseAndKey}sms/status.json?messageid={0}"; } }
        public string StatusByMessageId { get { return $"{_baseAndKey}sms/statuslocalmessageid.json?localid={0}"; } }
        public string @Select { get { return $"{_baseAndKey}sms/select.json?messageid={0}"; } }
        public string SelectOutbox { get { return $"{_baseAndKey}sms/selectoutbox.json?startdate={0}"; } }
        public string Receive { get { return $"{_baseAndKey}sms/receive.json?linenumber={0}&isread=0"; } }
        public string Cancel { get { return $"{_baseAndKey}sms/cancel.json?messageid={0}"; } }
        public string CountInbox { get { return $"{_baseAndKey}sms/countoutbox.json?startdate={0}"; } }
        public string Lookup { get { return $"{_baseAndKey}verify/lookup.json?receptor={0}&token={1}&template={2}"; } }
        public string Maketts { get { return $"{_baseAndKey}call/maketts.json?receptor={0}&message={1}"; } }
        public string Info { get { return $"{_baseAndKey}account/info.json"; } }
        public string Config { get { return $"{_baseAndKey}account/config.json"; } }
        public string LatestOutbox { get { return $"{_baseAndKey}sms/latestoutbox.json"; } }
    }
}
