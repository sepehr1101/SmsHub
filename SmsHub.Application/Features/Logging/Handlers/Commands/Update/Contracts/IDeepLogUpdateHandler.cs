using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts
{
    public interface IDeepLogUpdateHandler
    {
        Task Handle(UpdateDeepLogDto updateDeepLogDto, CancellationToken cancellationToken);
    }
}
