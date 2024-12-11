namespace SmsHub.Application.Exceptions
{
    public class ProviderCredentialException : Exception
    {
        public string _ProviderName { get; }
        public ProviderCredentialException(string providerName)
            : base(string.Format(ExceptionLiterals.ProviderException, providerName))
        {
            _ProviderName = providerName;
        }

    }

}
