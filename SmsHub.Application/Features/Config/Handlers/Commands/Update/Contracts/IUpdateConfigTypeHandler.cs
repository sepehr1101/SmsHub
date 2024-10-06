using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IUpdateConfigTypeHandler
    {
        Task Handle(UpdateConfigTypeDto updateConfigTypeDto, CancellationToken cancellationToken);
    }
}
