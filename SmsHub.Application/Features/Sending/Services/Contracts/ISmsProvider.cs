using SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using System.Runtime.InteropServices;
using static SmsHub.Application.Features.Sending.Services.Implementations.GetStatusSingleService;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsProvider
    {
        Task<CreateMessageDetailStatusDto> Send(Entities.Line line, MobileText mobileText, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList);
        Task<ICollection<CreateMessageDetailStatusDto>> Send(Entities.Line line, ICollection<MobileText> mobileTexts, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList);
        Task<long> GetCredit(Entities.Line line, ICollection<ProviderResponseStatus> statusList);
        Task GetState(Entities.Line line, GetStatusDataNeed statusListData, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList);
        Task GetState(Entities.Line line, ICollection<GetStatusDataNeed> statusListData, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList);
        Task<ICollection<CreateReceiveDto>> Receive([Optional]Entities.Line line, ICollection<ProviderResponseStatus> statusList);        
    }
}
