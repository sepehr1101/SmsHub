using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts
{
    public interface IUpdateMessageHolderHandler
    {
        Task Handle(UpdateMessageHolderDto updateMessageHolderDto, CancellationToken cancellationToken);
    }
}
