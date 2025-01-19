using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using System.Runtime.InteropServices;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsProvider
    {
        Task Send(Entities.Line line, MobileText mobileText, ICollection<ProviderResponseStatus> statusList);
        Task<ICollection<CreateMessageDetailStatusDto>> Send(Entities.Line line, ICollection<MobileText> mobileTexts, ICollection<ProviderResponseStatus> statusList);
        Task<long> GetCredit(Entities.Line line, ICollection<ProviderResponseStatus> statusList);
        Task GetState(Entities.Line line,long id, ICollection<ProviderResponseStatus> statusList);
        Task<ICollection<CreateReceiveDto>> Receive([Optional]Entities.Line line, ICollection<ProviderResponseStatus> statusList);
     
    }
}
