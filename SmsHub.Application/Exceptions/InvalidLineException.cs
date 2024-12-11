namespace SmsHub.Application.Exceptions
{
    public class InvalidLineException:Exception
    {
        public InvalidLineException():base(ExceptionLiterals.InvalidLineId)
        {
        }
    }
}
