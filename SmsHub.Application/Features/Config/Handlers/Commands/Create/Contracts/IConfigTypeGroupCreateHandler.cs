using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts
{
    public interface IConfigTypeGroupCreateHandler
    {
        Task Handle(CreateConfigTypeGroupDto request, CancellationToken cancellationToken);
    }
}