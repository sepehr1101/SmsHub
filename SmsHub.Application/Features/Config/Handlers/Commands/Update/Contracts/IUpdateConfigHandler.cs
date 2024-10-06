using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IUpdateConfigHandler
    {
        Task Handle(UpdateConfigDto updateConfigDto, CancellationToken cancellationToken);
    }
}
