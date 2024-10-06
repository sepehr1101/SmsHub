using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts
{
    public interface ICreateOperationTypeCommandHandler
    {
        Task Handle(CreateOperationTypeDto request, CancellationToken cancellationToken);
    }
}