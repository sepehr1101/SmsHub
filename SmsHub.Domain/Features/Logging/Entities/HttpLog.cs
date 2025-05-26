using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Logging.Entities
{
    [Table(nameof(HttpLog))]
    public class HttpLog
    {
        public long Id { get; set; }
        public DateTime RequestDateTime { get; set; } = DateTime.Now;
        public string Method { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string? RequestHeaders { get; set; }
        public string? RequestBody { get; set; }

        public int StatusCode { get; set; }
        public string? ReasonPhrase { get; set; }
        public string? ResponseHeaders { get; set; }
        public string? ResponseBody { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
