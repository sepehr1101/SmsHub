using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class ProviderCredentialByInvalidPropertyException : BaseException
    {
        public ProviderCredentialByInvalidPropertyException(string providerName,string property)
            : base(ExceptionLiterals.ProviderWithInvalidProperty(providerName,property))
        {
        }

    }

}
