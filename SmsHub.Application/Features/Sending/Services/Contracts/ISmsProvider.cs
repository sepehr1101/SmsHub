using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsProvider
    {
        Task Send(Entities.Line line, MobileText mobileText);
        Task Send(Entities.Line line, ICollection<MobileText> mobileTexts);
        Task<long> GetCredit(Entities.Line line);
        Task GetState(Entities.Line line,long id);

        void Test();
        //Task Send(Line line, MobileText mobileText);
    }
}
