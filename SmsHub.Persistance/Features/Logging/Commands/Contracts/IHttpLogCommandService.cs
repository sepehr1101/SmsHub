using SmsHub.Domain.Features.Logging.Entities;

namespace SmsHub.Persistence.Features.Logging.Commands.Contracts
{
    public interface IHttpLogCommandService
    {
        Task Add(HttpLog httpLog);
    }
}