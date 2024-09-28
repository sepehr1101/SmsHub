using SmsHub.Persistence.Constants.Literals;

namespace SmsHub.Persistence.Exceptions
{
    public class InvalidIdException:Exception
    {
        public InvalidIdException():base(ExceptionLiterals.InvalidIdentifier)
        {
            
        }
    }
}
