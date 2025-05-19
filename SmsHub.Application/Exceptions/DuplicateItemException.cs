using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class DuplicateItemException : BaseException
    {
        public DuplicateItemException() : base(ExceptionLiterals.DuplicateItem)
        {
        }
    }
}
