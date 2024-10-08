using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts
{
    public interface IConsumerLineUpdateHandler
    {
        Task Handle(UpdateConsumerLineDto updateConsumerLineDto, CancellationToken cancellationToken);
    }

}
