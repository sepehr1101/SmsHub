using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts
{
    public interface IUpdateInformativeLogHandler
    {
        Task Handle(UpdateInformativeLogDto updateInformativeLogDto, CancellationToken cancellationToken);
    }
}
