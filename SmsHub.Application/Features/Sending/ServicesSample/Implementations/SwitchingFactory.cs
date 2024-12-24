using Microsoft.Extensions.DependencyInjection;
using SmsHub.Application.Features.Sending.ServicesSample.Contracts;
using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.ServicesSample.Implementations
{
    public class SwitchingFactory : ISwitchingFactory
    {
        private readonly Dictionary<int, IProviderFactory> _providers;
        public SwitchingFactory(IServiceProvider serviceProvider)
        {
            _providers = new Dictionary<int, IProviderFactory>()
            {
                {Convert.ToInt32(ProviderEnum.Magfa),serviceProvider.GetRequiredService<Magfa>() },
                { Convert.ToInt32(ProviderEnum.Kavenegar),serviceProvider.GetRequiredService<Kavenegar>()}
            };
        }

        public async Task GetAccount_Balance(int id)//run
        {
            if (_providers.TryGetValue(id, out var provider))
                await provider.Account_Balance();
            else
                throw new InvalidOperationException();
        }

        public async Task GetStatusByMessageId(int id, int messageId)//run
        {
            if (_providers.TryGetValue(id, out var provider))
                await provider.Status_Statuses(messageId);
            else
                throw new InvalidOperationException();
        }

        public async Task GetReceiveMessages(int lineId, int? count, string? lineNumber)//run
        {
            if (_providers.TryGetValue(lineId, out var provider))
                await provider.Receive_Messages(count, lineNumber);
            else
                throw new InvalidOperationException();
        }

        public async Task SendMessages(int lineId, List<SendMessageDto> sendMessage)//run
        {
            if(_providers.TryGetValue(lineId, out var provider))
                await provider.Send_Send(sendMessage);
            else
                throw new InvalidOperationException();
        }

        public async Task GetStatusByLocalMessageId(int lineId, long localMessageId)//run
        {
             if(_providers.TryGetValue(lineId,out var provider))
                await provider.StatusByLocalMessageId_(localMessageId);
             else
                throw new InvalidOperationException();
        }

        public async Task GetMessageIdByUserId(int lineId, long userId)//run
        {
            if (_providers.TryGetValue(lineId,out var provider))
                await provider._Mid(userId);
            else
                throw new InvalidOperationException();
        }

        public async Task GetMessageInfoByMessageId(int lineId, long messageId)//see Kavenagar Class
        {
            if(_providers.TryGetValue(lineId,out var provider))
                await provider.SelectMessage_(messageId);
            else
                throw new InvalidOperationException();
        }

        public async Task GetMessageListSent(int lineId, long startDate, long endDate, string lineNumber)//run
        {
            if(_providers.TryGetValue(lineId,out var provider))
                await provider.SelectOutbox_(startDate, endDate, lineNumber);
            else
                throw new InvalidOperationException();
        }

        public async Task GetLatestMessageByMessageCount(int lineId, long count, string lineNumber)//run
        {
            if(_providers.TryGetValue(lineId,out var provider))
                await provider.LatestOutbox_(count, lineNumber);
            else
                throw new InvalidOperationException();
        }

       
    }
}
