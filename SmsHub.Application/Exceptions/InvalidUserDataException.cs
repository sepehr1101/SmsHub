using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class InvalidUserDataException: BaseException
    {
        public InvalidUserDataException():base(ExceptionLiterals.InvalidUserData)
        {
        }
    }
}
