namespace SmsHub.Domain.Providers.Asanak.constants
{
    public class Literals
    {
        public string BaseUrl { get { return @"https://panel.asanak.com/webservice/v2rest"; } }
        public string _UserName { get { return @"USER NAME"; } }
        public string _Password { get { return @"PASSWORD"; } }

        private string _baseAndKey { get { return $"{BaseUrl}/"; } }
        private string sendSmsUri { get { return $"{_baseAndKey}sendsms.json?username={_UserName}&password={_Password}&source={0}&destination={1}&message={2}"; } }
        private string MsgStatusUri { get { return $"{_baseAndKey}msgstatus.json?Username={_UserName}&Password={_Password}&msgid={0}"; } }
        private string GetCreditUri { get { return $"{_baseAndKey}getcredit.json??username={_UserName}&password={_Password}"; } }
        private string TemplateUri { get { return $"{_baseAndKey}template.json"; } }
        private string P2PSendSmsUri { get { return $"{_baseAndKey}p2psendsms.json"; } }
        private string GetrialCreditUri { get { return $"{_baseAndKey}getrialcredit.json"; } }

    }
}
