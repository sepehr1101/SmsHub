using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public  interface IPermittedTimeDeleteHandler
    {
        Task Handle(DeletePermittedTimeDto deletePermittedTimeDto, CancellationToken cancellationToken);

    }
}
