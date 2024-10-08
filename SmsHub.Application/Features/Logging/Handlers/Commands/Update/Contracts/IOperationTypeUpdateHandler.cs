using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts
{
    public interface IOperationTypeUpdateHandler
    {
        Task Handle(UpdateOperationTypeDto updateOperationTypeDto, CancellationToken cancellationToken);
    }
}
