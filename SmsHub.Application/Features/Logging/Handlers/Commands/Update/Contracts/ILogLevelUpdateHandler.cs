using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts
{
    public interface ILogLevelUpdateHandler
    {
        Task Handle(UpdateLogLevelDto updateLogLevelDto, CancellationToken cancellationToken);
    }
}
