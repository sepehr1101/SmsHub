using SmsHub.Common.Literals;

namespace SmsHub.Common.Exceptions
{
    public class InvalidIdException: BaseException
    {
        public InvalidIdException(): base(ExceptionLiterals.IdNotMoreThan0)
        {
        }
    }
}
