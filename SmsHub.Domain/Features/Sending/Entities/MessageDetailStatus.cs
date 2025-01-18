using SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Sending.Entities
{
    public class MessageDetailStatus
    {
        public long  Id { get; set; }
        public DateTime ReceiveDateTime {  get; set; }
        public long MessageId {  get; set; }
        public long MessagesDetailId {  get; set; }
        public int ProviderResponseStatusId {  get; set; }

        public virtual ProviderResponseStatus ProviderResponseStatus { get; set; }
        public virtual MessagesDetail MessagesDetail { get; set; }

    }
}
