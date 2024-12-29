using SmsHub.Common.Literals;

namespace SmsHub.Common.Exceptions
{
    public class RootProjectNotFoundException: BaseException
    {
        public RootProjectNotFoundException(string applicationBasePath)
            :base($"{ExceptionLiterals.AppBasePathNotFound_1} {applicationBasePath}")
        {
            
        }
    }
}
