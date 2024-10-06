using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ICreateMessageStateCommandHandler
    {
        Task Handle(CreateMessageStateDto request, CancellationToken cancellationToken);
    }
}