namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface IInformativeLogCommandService
    {
        Task Add(Domain.Features.Entities.InformativeLog informativeLog);
        Task Add(ICollection<Domain.Features.Entities.InformativeLog> informativeLogs);
    }
}
