using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsProvider
    {
        Task Send(Entities.Line line, MobileText mobileText);
        Task Send(Entities.Line line, ICollection<MobileText> mobileTexts);
        Task<long> GetCredit();
        Task GetState(long id);
        //Task Send(Line line, MobileText mobileText);
    }
}
