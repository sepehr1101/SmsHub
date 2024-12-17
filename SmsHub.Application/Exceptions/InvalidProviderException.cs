namespace SmsHub.Application.Exceptions
{
    public class InvalidProviderException:Exception
    {
        public InvalidProviderException()
            :base(ExceptionLiterals.InvalidProviderId)
        {
        }
    }
}
