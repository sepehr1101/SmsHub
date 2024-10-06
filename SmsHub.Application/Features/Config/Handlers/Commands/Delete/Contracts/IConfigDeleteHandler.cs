using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public interface IConfigDeleteHandler
    {
        Task Handle(DeleteConfigDto deleteConfigDto, CancellationToken cancellationToken);

    }
}
