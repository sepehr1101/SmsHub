using System.Diagnostics.CodeAnalysis;

namespace SmsHub.Common.UseragentLog
{
    public record LogInfo
    {
        [AllowNull]
        public Device Device { get; set; }

        [AllowNull]
        public Os Os { get; set; }

        [AllowNull]
        public Client Client { get; set; }

        [AllowNull]
        public Bot Bot { get; set; }
    }
}