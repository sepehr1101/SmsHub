using SmsHub.Common.Literals;

namespace SmsHub.Application.Exceptions
{
    public class ProviderCredentialException : Exception
    {
        public string _ProviderName { get; }
        public ProviderCredentialException(string providerName)
            : base(string.Format(BaseMessage, providerName))
        {
            _ProviderName = providerName;
        }
        private static string BaseMessage => "احراز هویت _Provider {0}_ ناصحیح است";


    }

}
