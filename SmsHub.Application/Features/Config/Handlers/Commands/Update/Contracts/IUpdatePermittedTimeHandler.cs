using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IUpdatePermittedTimeHandler
    {
        Task Handle(UpdatePermittedTimeDto updatePermittedTimeDto, CancellationToken cancellationToken);
    }
}
