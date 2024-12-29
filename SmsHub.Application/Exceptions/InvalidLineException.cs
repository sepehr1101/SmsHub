using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class InvalidLineException: BaseException
    {
        public InvalidLineException():base(ExceptionLiterals.InvalidLineId)
        {
        }
    }
}
