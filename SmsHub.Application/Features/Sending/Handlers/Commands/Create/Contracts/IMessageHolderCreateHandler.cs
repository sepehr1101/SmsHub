using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public interface IMessageHolderCreateHandler
    {
        Task Handle(CreateMessagesHolderDto request, CancellationToken cancellationToken);
    }
}