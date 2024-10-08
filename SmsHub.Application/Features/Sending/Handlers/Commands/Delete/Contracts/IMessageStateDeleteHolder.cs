using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts
{
    public interface IMessageStateDeleteHolder
    {
        Task Handle(DeleteMessageStateDto deleteMessageStateDto, CancellationToken cancellationToken);
    }
}
