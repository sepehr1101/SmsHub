using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts
{
    public interface IConsumerDeleteHandler
    {
        Task Handle(DeleteConsumerDto deleteConsumerDto, CancellationToken cancellationToken);

    }
}
