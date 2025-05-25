using System.Text.Json.Serialization;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Base
{
    public class ResponseBase
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
