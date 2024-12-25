namespace SmsHub.Application.Exceptions
{
   public class InvalidProviderHandleException:Exception
    {
        public InvalidProviderHandleException()
            :base(ExceptionLiterals.InvalidProviderHandle)
        {

        }
    }
}
