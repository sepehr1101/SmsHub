using SmsHub.Common.Exceptions;
using SmsHub.Persistence.Constants.Literals;

namespace SmsHub.Persistence.Exceptions
{
    public class InvalidIdException:BaseException
    {
        public InvalidIdException():base(ExceptionLiterals.InvalidIdentifier)
        {
            
        }
    }
}
