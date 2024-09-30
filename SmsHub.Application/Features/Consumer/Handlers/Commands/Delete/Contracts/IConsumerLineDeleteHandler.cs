using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts
{
    public interface IConsumerLineDeleteHandler
    {
        Task Handle(DeleteConsumerLineDto deleteConsumerLineDto, CancellationToken cancellationToken);

    }
}
