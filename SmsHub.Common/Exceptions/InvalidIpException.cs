using SmsHub.Common.Extensions;
using SmsHub.Common.Literals;

namespace SmsHub.Common.Exceptions
{
    public class InvalidIpException: BaseException
    {
        public InvalidIpException(string ip)
            :base(string.Format(ExceptionLiterals.InvalidIp,ip)) 
        {
            ip.NotNull();
        }
    }
}
