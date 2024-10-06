using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ICreateMessageBatchCommandHandler
    {
        Task Handle(CreateMessageBatchDto request, CancellationToken cancellationToken);
    }
}