using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts
{
    public interface ICreateConfigCommandHandler
    {
        Task Handle(CreateConfigDto request, CancellationToken cancellationToken);
    }
}