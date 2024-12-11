using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Services
{
    public static class MessageBatchFactory 
    { 
        public static MessageBatch Create(ICollection<MobileText> mobileTexts, int lineId, object metadata)
        {
            var messageDetails = mobileTexts.Select(GetMessageDetail);

            MessageBatch messageBatch = new MessageBatch();
            return messageBatch;
        }
        private static MessagesDetail GetMessageDetail(MobileText mobileText) 
        {
            return new MessagesDetail()
            {
                Text = mobileText.Text,
                Receptor = mobileText.Mobile,
                SendDateTime = DateTime.Now,
                SmsCount = GetMessageCount(mobileText.Text)                
            };
        }
        private static short GetMessageCount(string text) 
        {
            return 0;
        }
    }
}