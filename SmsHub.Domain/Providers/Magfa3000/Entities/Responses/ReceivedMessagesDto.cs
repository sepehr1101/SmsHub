using SmsHub.Domain.Providers.Magfa3000.Entities.Base;
using System.Text.Json.Serialization;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class ReceivedMessagesDto:ResponseBase
    {
        [JsonPropertyName("messages")]
        public ICollection<ResponseReceivedMessagesDto>? Messages { get; set; }
    }

    public class ResponseReceivedMessagesDto
    {
        [JsonPropertyName("body")]
        public string Body { get; set; } = default!;

        [JsonPropertyName("senderNubmer")]
        public string SenderNubmer { get; set; } = default!;

        [JsonPropertyName("recipientNumber")]
        public string RecipientNumber { get; set; } = default!;

        [JsonPropertyName("date")]
        public string Date { get; set; } = default!;
    }
}