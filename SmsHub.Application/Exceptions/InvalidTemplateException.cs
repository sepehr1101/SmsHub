namespace SmsHub.Application.Exceptions
{
    public class InvalidTemplateException:Exception
    {
        public InvalidTemplateException():base(ExceptionLiterals.InvalidTemplateId)
        {
        }
    }
}
