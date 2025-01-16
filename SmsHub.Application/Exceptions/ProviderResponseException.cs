using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class ProviderResponseException:BaseException
    {
        public ProviderResponseException(string message,int statusCode)
            :base(ExceptionLiterals.InvalidProviderResponse(message, statusCode))
        {

        }
    }
}
