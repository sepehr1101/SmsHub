using Microsoft.Extensions.Logging;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update;
using SmsHub.Infrastructure.BaseHttp.Interceptors.Contracts;
using SmsHub.Persistence.Features.Logging.Raw;

namespace SmsHub.Infrastructure.BaseHttp.Interceptors.Implementations
{
    public class SqlLoggingInterceptor : IHttpInterceptor
    {
        private readonly SqlLogger _sqlLogger;
        //private readonly ILogger<SqlLoggingInterceptor> _logger;

        private static readonly HttpRequestOptionsKey<long> HttpLogIdKey = new("HttpLogId");
        private static readonly HttpRequestOptionsKey<DateTime> RequestTimestampKey = new("RequestTimestamp");

        public SqlLoggingInterceptor(
            SqlLogger sqlLogger,
            ILogger<SqlLoggingInterceptor> logger)
        {
            _sqlLogger = sqlLogger;
            _sqlLogger.NotNull(nameof(sqlLogger));
            //_logger = logger;
        }

        public async Task OnRequestAsync(HttpRequestMessage request)
        {
            try
            {
                var timestamp = DateTime.Now;
                request.Options.Set(RequestTimestampKey, timestamp);

                var log = new HttpLog
                {
                    Method = request.Method.ToString(),
                    Url = request.RequestUri?.ToString(),
                    RequestHeaders = request.Headers?.ToString(),
                    RequestBody = request.Content != null ? await request.Content.ReadAsStringAsync() : null,
                    RequestDateTime = DateTime.UtcNow
                };

                long logId = await _sqlLogger.InsertHttpLogAsync(log);
                request.Options.Set(HttpLogIdKey, logId);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Failed to log HTTP request");
            }
        }

        public async Task OnResponseAsync(HttpResponseMessage response)
        {
            try
            {
                if (
                    !response.RequestMessage.Options.TryGetValue(HttpLogIdKey, out long logId) ||
                    !response.RequestMessage.Options.TryGetValue(RequestTimestampKey, out DateTime requestTimestamp))
                {
                    //_logger.LogWarning("Missing log correlation data");
                    return;
                }

                var update = new HttpLogUpdate(
                    StatusCode: (int)response.StatusCode,
                    ReasonPhrase: response.ReasonPhrase,
                    ResponseHeaders: response.Headers?.ToString(),
                    ResponseBody: response.Content != null ? await response.Content.ReadAsStringAsync() : null,
                    Duration: DateTime.Now - requestTimestamp
                );

                await _sqlLogger.UpdateHttpLogAsync(logId, update);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Failed to log HTTP response");
            }
        }
    }
}
