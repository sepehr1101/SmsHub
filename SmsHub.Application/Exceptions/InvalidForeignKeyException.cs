using SmsHub.Common.Exceptions;

namespace SmsHub.Application.Exceptions
{
    public class InvalidForeignKeyException:BaseException
    {
        public InvalidForeignKeyException(string tebleName)
            :base(ExceptionLiterals.InvalidForeignKey(tebleName))
        {
        } 
    }
}
