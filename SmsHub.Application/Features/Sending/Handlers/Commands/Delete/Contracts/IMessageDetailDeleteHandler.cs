using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts
{
    public interface IMessageDetailDeleteHandler
    {
        Task Handle(DeleteMessageDetailDto deleteMessageDetailDto, CancellationToken cancellationToken);
    }
}
