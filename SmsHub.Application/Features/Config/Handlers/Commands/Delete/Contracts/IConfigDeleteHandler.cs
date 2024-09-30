using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public interface IConfigDeleteHandler
    {
        Task Handle(DeleteConfigDto deleteConfigDto, CancellationToken cancellationToken);

    }
}
