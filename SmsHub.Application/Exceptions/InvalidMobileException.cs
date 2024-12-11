namespace SmsHub.Application.Exceptions
{
    public class InvalidMobileException : Exception
    {
        public InvalidMobileException() : base(ExceptionLiterals.InvalidMobile)
        {
        }
    }
}
