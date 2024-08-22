using SmsHub.Common.Literals;

namespace SmsHub.Common.Exceptions
{
    public class ArgumentIsNullException:ArgumentException
    {
        public ArgumentIsNullException(string argumentName)
            :base($"{ExceptionLiterals.ArgumentIsNull_1} {argumentName}") 
        {            
        }
    }
}
