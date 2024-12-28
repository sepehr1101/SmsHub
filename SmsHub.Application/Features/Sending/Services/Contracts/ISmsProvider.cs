using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Services.Contracts
{
    public interface ISmsProvider
    {
        Task Send(string lineNumber, MobileText mobileText);
        Task Send(string lineNumber, ICollection<MobileText> mobileTexts);
        Task<long> GetCredit();
        Task GetState(long id);
    }
}
