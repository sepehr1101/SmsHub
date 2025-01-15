using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Application.Common.Services.Implementations;
using System.Runtime.InteropServices;
using SmsHub.Domain.Providers.Magfa3000.Entities.Responses;
using SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.Entities;


namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public class MagfaProvider : ISmsProvider
    {
        private readonly IMagfa300HttpSendService _magfaSendService;
        private readonly IMagfa300HttpStatusesService _magfaStatusCodesService;
        private readonly IMagfa300HttpBalanceService _magfaBalanceService;
        private readonly IMagfa300HttpMidService _magfaMidService;
        private readonly IMagfa300HttpMessagesService _magfaMessagesService;


        public MagfaProvider(
            IMagfa300HttpSendService magfaSendService,
            IMagfa300HttpStatusesService magfaStatusCodesService,
            IMagfa300HttpBalanceService magfaBalanceService,
            IMagfa300HttpMidService magfaMidService,
            IMagfa300HttpMessagesService magfaMessagesService)
        {
            _magfaSendService = magfaSendService;
            _magfaSendService.NotNull(nameof(MagfaProvider));

            _magfaStatusCodesService = magfaStatusCodesService;
            _magfaStatusCodesService.NotNull(nameof(MagfaProvider));

            _magfaBalanceService = magfaBalanceService;
            _magfaBalanceService.NotNull(nameof(magfaBalanceService));

            _magfaMidService = magfaMidService;
            _magfaMidService.NotNull(nameof(magfaMidService));

            _magfaMessagesService = magfaMessagesService;
            _magfaMessagesService.NotNull(nameof(magfaMessagesService));
        }
        public void Test()
        {
            Console.WriteLine("test from magfa");
        }
        public async Task<long> GetCredit(Entities.Line line)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var result = await _magfaBalanceService.GetBalances(domain, userName, password);

            return result.Balance;
        }



        public async Task GetState(Entities.Line line,ICollection<long> id)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;
            
            var result = await _magfaStatusCodesService.GetStatuses(domain, userName, password, id);
        }

        public async Task GetState(Entities.Line line,long id)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;
            
            var result = await _magfaStatusCodesService.GetStatuses(domain, userName, password, id);
        }




        public async Task Send(Entities.Line line, MobileText mobileText)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var sendDto = new MagfaRequest.SendDto()
            {
                messages = new List<string> { mobileText.Text },
                recipients = new List<string> { mobileText.Mobile },
                uids = new List<long> { mobileText.LocalId },
                senders = new List<string> { line.Number },

            };

            var result = await _magfaSendService.SendMessage(domain, userName, password, sendDto);

        }

        public async Task Send(Entities.Line line, ICollection<MobileText> mobileText)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            MagfaRequest.SendDto sendDto = new MagfaRequest.SendDto()
            {
                messages = new List<string>(),
                recipients = new List<string>(),
                uids = new List<long>(),
                senders = new List<string>(),
            };

            foreach (var item in mobileText)
            {
                sendDto.senders.Add(line.Number);
                sendDto.messages.Add(item.Text);
                sendDto.uids.Add(item.LocalId);
                sendDto.recipients.Add(item.Mobile);
            }

            var result = await _magfaSendService.SendMessage(domain, userName, password, sendDto);

        }




        private async Task Mid(Entities.Line line,long userId)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;
            
            var result = await _magfaMidService.GetMid(domain, userName, password, userId);
        }


        public async Task<ICollection<CreateReceiveDto>> Receive([Optional] Entities.Line line, ICollection<ProviderResponseStatus> statusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var result = await _magfaMessagesService.GetMessages(domain, userName, password);

            //mapping to CreateReceiveDto
            ICollection<CreateReceiveDto> createReceiveMessage=new List<CreateReceiveDto>();
            foreach (var item in result.Messages)
            {
                var receiveSingleMessage = new CreateReceiveDto(item);
                createReceiveMessage.Add(receiveSingleMessage);
            }
            return createReceiveMessage;
        }
    }
}
