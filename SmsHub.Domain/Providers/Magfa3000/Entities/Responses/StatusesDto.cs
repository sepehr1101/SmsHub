using SmsHub.Domain.Providers.Magfa3000.Entities.Base;
using System.Text.Json.Serialization;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class StatusesDto:ResponseBase
    {
        [JsonPropertyName("Dlrs")]
        public ICollection<DlrsDto> Dlrs { get; set; }

    }
    public class DlrsDto
    {
        [JsonPropertyName("mid")]
        public long Mid { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }
    }
}
