using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class ProviderCredentialException: BaseException
    {
        public ProviderCredentialException()
            :base(ExceptionLiterals.ProviderCredential)
        {
        }
    }
}
