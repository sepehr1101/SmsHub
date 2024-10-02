using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts
{
    public interface IMessageBatchDeleteHandler
    {
        Task Handle(DeleteMessageBatchDto deleteMessageBatchDto, CancellationToken cancellationToken);
    }
}
