using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts
{
    public interface IConsumerSafeIpDeleteHandler
    {
        Task Handle(DeleteConsumerSafeIpDto deleteConsumerSafeIpDto, CancellationToken cancellationToken);

    }
}
