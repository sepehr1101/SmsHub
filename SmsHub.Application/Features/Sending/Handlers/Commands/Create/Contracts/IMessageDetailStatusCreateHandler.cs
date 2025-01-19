using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface IMessageDetailStatusCreateHandler
    {
        Task Handle(CreateMessageDetailStatusDto request,CancellationToken cancellationToken);
    }
}
