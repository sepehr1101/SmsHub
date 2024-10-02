using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface IInformativeLogCommandService
    {
        Task Add(InformativeLog informativeLog);
        Task Add(ICollection<InformativeLog> informativeLogs);
        void Delete(InformativeLog informativeLog);
    }
}
