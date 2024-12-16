using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Line.Handlers.Queries.Implementations;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Line.Queries.Implementations;
using SmsHub.Persistence.Features.Sending.Queries.Implementations;
using System.Collections.Generic;
using System.Text;

namespace SmsHub.Application.Features.Sending.Services
{
    public static class MessageBatchFactory
    {
        public static MessageBatch Create(ICollection<MobileText> mobileTexts, int lineId, object metadata)
        {
            var messageDetails = mobileTexts.Select(GetMessageDetail);

            var batchSize = 2;//for example
            var messageHolderCount = (mobileTexts.Count % batchSize) == 0 ? (mobileTexts.Count/batchSize) : (mobileTexts.Count /batchSize) + 1;

            var x = messageDetails
                      .Select((x, i) => new { Index = i, Value = x })
                      .GroupBy(x => x.Index / batchSize)
                      .Select(g => g.Select(x => x.Value));
            
            var messageHolders = x.Select(GetMessageHolder);

            MessageBatch messageBatch = new MessageBatch()
            {
                InsertDateTime= DateTime.Now,
                AllSize=mobileTexts.Count,
                HolderSize=messageHolders.Count(),
                LineId=lineId,
                MessagesHolders=messageHolders.ToList()
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