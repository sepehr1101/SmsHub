using SmsHub.Domain.Features.Line.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts
{
    public interface ICreateProviderCommandHandler
    {
        Task Handle(CreateProviderDto request, CancellationToken cancellationToken);
    }
}