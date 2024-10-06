using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts
{
    public interface IConsumerDeleteHandler
    {
        Task Handle(DeleteConsumerDto deleteConsumerDto, CancellationToken cancellationToken);

    }
}
