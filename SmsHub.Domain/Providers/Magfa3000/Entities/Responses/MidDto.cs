using SmsHub.Domain.Providers.Magfa3000.Entities.Base;
using System.Text.Json.Serialization;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class MidDto : ResponseBase
    {
        [JsonPropertyName("mid")]
        public long Mid { get; set; }
    }
}
