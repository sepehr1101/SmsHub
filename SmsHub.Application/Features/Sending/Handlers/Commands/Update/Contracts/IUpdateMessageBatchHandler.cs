using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts
{
    public interface IUpdateMessageBatchHandler
    {
        Task Handle(UpdateMessageBatchDto updateMessageBatchDto, CancellationToken cancellationToken);
    }
}
