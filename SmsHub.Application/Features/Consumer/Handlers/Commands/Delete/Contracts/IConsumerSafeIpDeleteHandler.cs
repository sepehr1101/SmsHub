using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts
{
    public interface IConsumerSafeIpDeleteHandler
    {
        Task Handle(DeleteConsumerSafeIpDto deleteConsumerSafeIpDto, CancellationToken cancellationToken);

    }
}
