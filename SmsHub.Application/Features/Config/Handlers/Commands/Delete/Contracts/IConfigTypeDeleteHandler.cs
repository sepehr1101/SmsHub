using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public interface IConfigTypeDeleteHandler
    {
        Task Handle(DeleteConfigTypDto deleteConfigTypDto, CancellationToken cancellationToken);

    }
}
