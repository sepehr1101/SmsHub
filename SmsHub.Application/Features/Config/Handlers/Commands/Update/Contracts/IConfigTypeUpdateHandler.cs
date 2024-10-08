using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IConfigTypeUpdateHandler
    {
        Task Handle(UpdateConfigTypeDto updateConfigTypeDto, CancellationToken cancellationToken);
    }
}
