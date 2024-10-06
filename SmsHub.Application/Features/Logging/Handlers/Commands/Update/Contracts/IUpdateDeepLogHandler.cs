using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts
{
    public interface IUpdateDeepLogHandler
    {
        Task Handle(UpdateDeepLogDto updateDeepLogDto, CancellationToken cancellationToken);
    }
}
