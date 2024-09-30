using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public interface ICcSendDeleteHandler
    {
        Task Handle(DeleteCcSendDto deleteCcSendDto, CancellationToken cancellationToken);
    }
}
