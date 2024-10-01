using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts
{
    public interface ILogLevelDeleteHandler
    {
        Task Handle(DeleteLogLevelDto deleteLogLevelDto, CancellationToken cancellationToken);
    }
}
