using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts
{
    public interface IDeepLogDeleteHandler
    {
        Task Handle(DeleteDeepLogDto deleteDeepLogDto, CancellationToken cancellationToken);
    }
}
