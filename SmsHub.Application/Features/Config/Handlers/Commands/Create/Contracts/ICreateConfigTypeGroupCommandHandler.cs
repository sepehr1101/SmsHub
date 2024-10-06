using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts
{
    public interface ICreateConfigTypeGroupCommandHandler
    {
        Task Handle(CreateConfigTypeGroupDto request, CancellationToken cancellationToken);
    }
}