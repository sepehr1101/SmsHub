using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts
{
    public interface IMessageBatchUpdateHandler
    {
        Task Handle(UpdateMessageBatchDto updateMessageBatchDto, CancellationToken cancellationToken);
    }
}
