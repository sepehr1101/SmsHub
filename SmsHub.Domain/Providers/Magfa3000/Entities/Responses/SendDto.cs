using SmsHub.Domain.Providers.Magfa3000.Entities.Base;
using System.Text.Json.Serialization;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class SendDto:ResponseBase
    {
        [JsonPropertyName("messages")]
        public ICollection<SendMessageDto>? Messages {  get; set; }
    }
    public class SendMessageDto
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("userId")]
        public long? UserId { get; set; }

        [JsonPropertyName("parts")]
        public int Parts { get; set; }

        [JsonPropertyName("Ttariff")]
        public float Tariff { get; set; }

        [JsonPropertyName("alphabet")]
        public string? Alphabet { get; set; }

        [JsonPropertyName("recipient")]
        public string? Recipient { get; set; }
    }
}

