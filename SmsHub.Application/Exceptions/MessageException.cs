using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
 public class MessageException:BaseException
    {
        public MessageException(string message)
            :base(ExceptionLiterals.MessageError(message))
        {

        }
    }
}
