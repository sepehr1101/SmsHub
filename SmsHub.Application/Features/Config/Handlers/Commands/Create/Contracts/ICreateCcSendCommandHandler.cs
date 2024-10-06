using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts
{
    public interface ICreateCcSendCommandHandler
    {
        Task Handle(CreateCcSendDto request, CancellationToken cancellationToken);
    }
}