using SmsHub.Common.Exceptions;
using SmsHub.Common.Literals;
using System.Runtime.InteropServices;

namespace SmsHub.Common.Extensions
{
    public static class Guard
    {
        public static void NotNull(this object obj, [Optional] bool checkDynamic)
        {
            if (obj is null)
            {
                throw new ArgumentIsNullException(nameof(obj));
            }
            if (checkDynamic)
            {
                var dynamicObject=(object)obj;
                if (dynamicObject is null)
                {
                    throw new ArgumentIsNullException(nameof(dynamicObject));
                }
            }

        }
        public static void NotNull(this object obj, string name, [Optional]bool checkDynamic)
        {
            if (obj is null)
            {
                throw new ArgumentIsNullException(name);
            }
            if (checkDynamic)
            {
                var dynamicObj= (object)obj;
                if (dynamicObj is null)
                {
                    throw new ArgumentIsNullException(name);
                }
            }
        }
        public static string NotEmptyString(this object? value, string name)
        {
            var s = value as string ?? value?.ToString();
            if (s == null)
            {
                throw new ArgumentIsNullException(name);
            }
            return string.IsNullOrWhiteSpace(s) ? throw new ArgumentException(ExceptionLiterals.EmptyString, name) : s;
        }
    }
}