using Microsoft.AspNetCore.Http;
using SmsHub.Common.Extensions;

namespace SmsHub.Common.UseragentLog
{
    public static class LogInfoJson
    {
        public static string Get(HttpRequest request, bool skipBotDetection)
        {
            var logInfo = DeviceDetection.GetLogInfo(request, skipBotDetection);
            return logInfo.Marshal();
        }
        public static string Get()
        {
            LogInfo logInfo = new()
            {
                Bot = new Bot(),
                Client = new Client(),
                Device = new Device(),
                Os = new Os()
            };
            return logInfo.Marshal();
        }
    }
}
