using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class NotFoundItemException : BaseException
    {
        public NotFoundItemException()
            : base(ExceptionLiterals.NotFoundItem)
        {
        }
    }
}
