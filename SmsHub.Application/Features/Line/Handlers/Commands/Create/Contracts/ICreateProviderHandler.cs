using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts
{
    public interface ICreateProviderHandler
    {
        Task Handle(CreateProviderDto request, CancellationToken cancellationToken);
    }
}