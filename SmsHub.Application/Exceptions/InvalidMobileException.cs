using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class InvalidMobileException : BaseException
    {
        public InvalidMobileException() : base(ExceptionLiterals.InvalidMobile)
        {
        }
    }
}
