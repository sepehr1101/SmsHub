using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class ProviderCredentialByNullPropertyException: BaseException
    {
        public ProviderCredentialByNullPropertyException(string providerName)
            :base(ExceptionLiterals.ProviderWithNullProperty(providerName))
        {

        }
    }
}
