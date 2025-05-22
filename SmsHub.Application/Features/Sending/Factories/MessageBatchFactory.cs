using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using System.Text.RegularExpressions;

namespace SmsHub.Application.Features.Sending.Factories
{
    internal static class MessageBatchFactory
    {
        internal static MessageBatch Create(ICollection<MobileText> mobileTexts, int lineId, int batchSize, object metadata)
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
        private static MessagesHolder GetMessageHolder(IEnumerable<MessageDetail> messagesDetail)
        {
            return new MessagesHolder()
            {
                Id = new Guid(),//TODO: after update to .net 9 user Guid.CreateVersion7()
                InsertDateTime = DateTime.Now,
                RetryCount = 0,
                MessagesDetails = messagesDetail.ToList(),
                DetailsSize = messagesDetail.Count(),
                SendDone = false,
            };
        }
        private static MessageDetail GetMessageDetail(MobileText mobileText)
        {
            return new MessageDetail()
            {
                Text = mobileText.Text,
                Receptor = mobileText.Mobile,
                SendDateTime = DateTime.Now,
                SmsCount = 10//SmsCounter.CountSmsMessages(mobileText.Text)
            };
        }
    }
    file static class SmsCounter
    {
        internal static short CountSmsMessages(string text)
        {
            bool isNonAscii = true;//ContainsNonUnicodeCharacters(text);
            int maxCharsFirstSms = isNonAscii ? 70 : 160;
            int maxCharsSecondSms = isNonAscii ? 64 : 146;
            int maxCharsSubsequentSms = isNonAscii ? 67 : 153;

            short totalSms = 0;
            int remainingChars = text.Length;

            if (remainingChars <= maxCharsFirstSms)
            {
                return 1;
            }
            else
            {
                totalSms = 1;
                remainingChars -= maxCharsFirstSms;

                if (remainingChars <= maxCharsSecondSms)
                {
                    return (short)(totalSms + 1);
                }
                else
                {
                    totalSms += 1;
                    remainingChars -= maxCharsSecondSms;

                    // محاسبه پیامک‌های بعدی صفحه سوم به بعد
                    totalSms += (short)Math.Ceiling((double)remainingChars / maxCharsSubsequentSms);
                    return totalSms;
                }
            }
        }

        private static bool ContainsNonUnicodeCharacters(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            // الگوی تشخیص کاراکترهای غیر ASCII
            Regex nonUnicodeRegex = new (@"[^\x00-\x7F]", RegexOptions.Compiled);
            return nonUnicodeRegex.IsMatch(text);
        }
    }
}