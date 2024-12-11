using SmsHub.Common.Literals;

namespace SmsHub.Application.Exceptions
{
    public class InvalidIdException:Exception
    {
        public InvalidIdException(): base(ExceptionLiterals.IdNotMoreThan0)
        {
        }
    }
}
