using MagfaResponse = SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using KavenegarResponse = SmsHub.Domain.Providers.Kavenegar.Entities.Responses;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateReceiveDto
    {

        public long? MessageId { get; private set; }
        public string MessageText { get; private set; }
        public string Sender { get; private set; }
        public string Receptor { get; private set; }
        public DateTime ReceiveDateTime { get; private set; }
        public DateTime InsertDateTime { get; private set; }
        public int LineId { get; private set; }

        public CreateReceiveDto(KavenegarResponse.ReceiveDto items, int lineId)
        {
            DateTime reseiveDateTime = DateTimeOffset.FromUnixTimeSeconds(items.Date).DateTime;

            MessageId = items.MessageId;
            MessageText = items.Message;
            Sender = items.Sender;
            Receptor = items.Receptor;
            ReceiveDateTime = reseiveDateTime;
            InsertDateTime = DateTime.Now;
            LineId = lineId;
        }
        public CreateReceiveDto(MagfaResponse.ResponseReceivedMessagesDto items, int lineId)
        {
            MessageText = items.Body;
            Sender = items.SenderNubmer;
            Receptor = items.RecipientNumber;
            ReceiveDateTime = items.Date;
            InsertDateTime = DateTime.Now;
            LineId = lineId;
        }
    }
}
