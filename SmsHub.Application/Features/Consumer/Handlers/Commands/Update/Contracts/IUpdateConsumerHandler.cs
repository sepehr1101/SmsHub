using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts
{
    public interface IUpdateConsumerHandler
    {
        Task Handle(UpdateConsumerDto updateConsumerDto, CancellationToken cancellationToken);
    }
}
