using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public interface ICreateMessageHolderCommandHandler
    {
        Task Handle(CreateMessagesHolderDto request, CancellationToken cancellationToken);
    }
}