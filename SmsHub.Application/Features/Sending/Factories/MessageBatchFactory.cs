using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using System.Text;

namespace SmsHub.Application.Features.Sending.Factories
{
    public static class MessageBatchFactory
    {
        public static MessageBatch Create(ICollection<MobileText> mobileTexts, int lineId, int batchSize, object metadata)
        {
            var messageDetails = mobileTexts.Select(GetMessageDetail);

            var messageDetailsSegmentation = messageDetails
                      .Select((x, i) => new { Index = i, Value = x })
                      .GroupBy(x => x.Index / batchSize)
                      .Select(g => g.Select(x => x.Value));

            var messageHolders = messageDetailsSegmentation.Select(GetMessageHolder);

            MessageBatch messageBatch = new MessageBatch()
            {
                InsertDateTime = DateTime.Now,
                AllSize = mobileTexts.Count,
                HolderSize = messageHolders.Count(),
                LineId = lineId,
                MessagesHolders = messageHolders.ToList()
            };
            return messageBatch;
        }
        private static MessagesHolder GetMessageHolder(IEnumerable<MessagesDetail> messagesDetail)
        {
            return new MessagesHolder()
            {
                Id = new Guid(),
                InsertDateTime = DateTime.Now,
                RetryCount = 2,//
                MessagesDetails = messagesDetail.ToList(),
                DetailsSize = messagesDetail.Count(),
                SendDone = true,
            };
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
            var count = Convert.ToInt16(Encoding.UTF8.GetByteCount(text));
            return count;
        }

    }
}