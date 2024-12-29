using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
   public class InvalidProviderHandleException: BaseException
    {
        public InvalidProviderHandleException()
            :base(ExceptionLiterals.InvalidProviderHandle)
        {

        }
    }
}
