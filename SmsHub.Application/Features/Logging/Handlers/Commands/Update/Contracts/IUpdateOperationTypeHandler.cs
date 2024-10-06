using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts
{
    public interface IUpdateOperationTypeHandler
    {
        Task Handle(UpdateOperationTypeDto updateOperationTypeDto, CancellationToken cancellationToken);
    }
}
