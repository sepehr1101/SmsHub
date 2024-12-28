using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class InvalidTemplateException: BaseException
    {
        public InvalidTemplateException():base(ExceptionLiterals.InvalidTemplateId)
        {
        }
    }
}
