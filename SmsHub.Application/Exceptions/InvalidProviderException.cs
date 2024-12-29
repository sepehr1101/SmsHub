using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class InvalidProviderException: BaseException
    {
        public InvalidProviderException()
            :base(ExceptionLiterals.InvalidProviderId)
        {
        }
    }
}
