using SmsHub.Domain.Providers.Magfa3000.Entities.Base;
using System.Text.Json.Serialization;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class BalanceDto : ResponseBase
    {
        [JsonPropertyName("balance")]
        public long Balance { get; set; }
    }
}
