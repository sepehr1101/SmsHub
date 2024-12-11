namespace SmsHub.Application.Exceptions
{
    public class InvalidUserDataException:Exception
    {
        public InvalidUserDataException():base(ExceptionLiterals.InvalidUserData)
        {
        }
    }
}
