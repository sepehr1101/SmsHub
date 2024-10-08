using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts
{
    public interface IConfigCreateHandler
    {
        Task Handle(CreateConfigDto request, CancellationToken cancellationToken);
    }
}