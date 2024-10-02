using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts
{
    public interface IUpdateConsumerLineHandler
    {
        Task Handle(UpdateConsumerLineDto updateConsumerLineDto, CancellationToken cancellationToken);
    }

}
