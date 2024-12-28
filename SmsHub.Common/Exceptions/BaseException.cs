namespace SmsHub.Common.Exceptions
{
    public class BaseException : Exception
    {
        private string _message;
        public BaseException(string message)
            : base(message)
        {
            _message = message;
        }
    }

}

