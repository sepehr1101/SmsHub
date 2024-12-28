using Microsoft.Extensions.DependencyInjection;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.ServicesSample.Contracts;
using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.ServicesSample.Implementations
{
    public class SwitchingFactory : ISwitchingFactory
    {
        private readonly Dictionary<ProviderEnum, IProviderFactory> _providers;
        private readonly ProviderEnum _providerId;
        public SwitchingFactory(IServiceProvider serviceProvider,ProviderEnum providerId)
        {
            _providers = new Dictionary<ProviderEnum, IProviderFactory>()
            {
                {ProviderEnum.Magfa,serviceProvider.GetRequiredService<Magfa>() },
                { ProviderEnum.Kavenegar,serviceProvider.GetRequiredService<Kavenegar>()}
            };

            var flag = _providers.ContainsKey(_providerId);
            if (!flag)
                throw new InvalidProviderException();
        }

        public async Task GetAccount_Balance(ProviderEnum id)
        {
            if (_providers.TryGetValue(id, out var provider))
                await provider.Account_Balance();
            else
                throw new InvalidOperationException();
        }

        public async Task GetStatusByMessageId(ProviderEnum id, int messageId)
        {
            if (_providers.TryGetValue(id, out var provider))
                await provider.Status_Statuses(messageId);
            else
                throw new InvalidOperationException();
        }

        public async Task GetReceiveMessages(ProviderEnum lineId, int? count, string? lineNumber)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.Receive_Messages(count, lineNumber);
            else
                throw new InvalidOperationException();
        }

        public async Task SendMessages(ProviderEnum lineId, List<SendMessageDto> sendMessage)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.Send_Send(sendMessage);
            else
                throw new InvalidOperationException();
        }

        public async Task GetStatusByLocalMessageId(ProviderEnum lineId, long localMessageId)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.StatusByLocalMessageId_(localMessageId);
            else
                throw new InvalidOperationException();
        }

        public async Task GetMessageIdByUserId(ProviderEnum lineId, long userId)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider._Mid(userId);
            else
                throw new InvalidOperationException();
        }

        public async Task GetMessageInfoByMessageId(ProviderEnum lineId, long messageId)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.SelectMessage_(messageId);
            else
                throw new InvalidOperationException();
        }

        public async Task GetMessageListSent(ProviderEnum lineId, long startDate, long endDate, string lineNumber)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.SelectOutbox_(startDate, endDate, lineNumber);
            else
                throw new InvalidOperationException();
        }

        public async Task GetLatestMessageByMessageCount(ProviderEnum lineId, long count, string lineNumber)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.LatestOutbox_(count, lineNumber);
            else
                throw new InvalidOperationException();
        }


        public async Task GetMessageCountInbox(ProviderEnum lineId, long startDate, long endDate, string lineNumber, bool IsRead)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.CountInbox_(startDate, endDate, lineNumber, IsRead);
            else
                throw new InvalidOperationException();

            var pro=CheckProviderEnum(lineId);
            await pro.CountInbox_(startDate,endDate, lineNumber, IsRead);
        }


        public IProviderFactory CheckProviderEnum(ProviderEnum lineId)
        {
            if (_providers.TryGetValue(lineId, out var provider))
                return provider;

            throw new InvalidProviderException();
        }

    }
}
