using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts
{
    public interface IUpdateConsumerSafaIpHandler
    {
        Task Handle(UpdateConsumerSafeIpDto updateConsumerSafeIpDto, CancellationToken cancellationToken);
    }
}
