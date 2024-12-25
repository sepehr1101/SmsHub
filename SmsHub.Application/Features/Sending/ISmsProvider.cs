using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending
{
    public interface ISmsProvider
    {
        Task Send(string lineNumber, MobileText mobileText);
        Task Send(string lineNumber, ICollection<MobileText> mobileTexts);
        Task<long> GetCredit(string lineNumber);
        Task GetState(long id);
    }
}
