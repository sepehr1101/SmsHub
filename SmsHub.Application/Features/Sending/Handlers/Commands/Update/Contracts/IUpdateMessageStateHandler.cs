using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts
{
    public interface IUpdateMessageStateHandler
    {
        Task Handle(UpdateMessageStateDto updateMessageStateDto, CancellationToken cancellationToken);
    }
}
