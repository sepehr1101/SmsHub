using System;

namespace SmsHub.Common
{
    public static class GuardExtensions
    {
        /// <summary>
        /// Checks if the argument is null.
        /// </summary>
        public static void CheckArgumentIsNull(this object o, string name)
        {
            if (o == null)
                throw new ArgumentNullException(name);
        }
        public static void CheckArgumentIsNull(this object o)
        {
            if (o == null)
                throw new ArgumentNullException(nameof(o));
        }

        public static void CheckStringIsNullOrWhiteSpace(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException(string.Concat(str, " Is Null"));
        }

        public static void CheckIsNumeric(this string str)
        {
            var isNumeric = int.TryParse(str, out _);
            if (!isNumeric)
                throw new ArgumentException(string.Concat(str, " Is Not Numeric"));
        }
    }
}
