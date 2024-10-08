using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts
{
    public interface IMessageHolderDeleteHandler
    {
        Task Handle(DeleteMessageHolderDto deleteMessageHolderDto, CancellationToken cancellationToken);
    }
}
