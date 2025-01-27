using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class FluentValidationException : BaseException
    {
        public FluentValidationException(string message)
            : base(ExceptionLiterals.FluentValidationMessage(message))
        {
        }
    }
}
