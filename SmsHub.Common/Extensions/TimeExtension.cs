namespace SmsHub.Common.Extensions
{
    public static class TimeExtension
    {
        public static long DateTimeToUnixTime(DateTime dateTime)
        {
            long unixTimeSeconds = new DateTimeOffset(dateTime).ToUnixTimeSeconds();
             return unixTimeSeconds;
        }
    }
}
