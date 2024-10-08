using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts
{
    public interface IConsumeSafeIprCreateHandler
    {
        Task Handle(CreateConsumerSafeIpDto request, CancellationToken cancellationToken);
    }
}
