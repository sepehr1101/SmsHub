using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts
{
    public interface IProviderCreateHandler
    {
        Task Handle(CreateProviderDto request, CancellationToken cancellationToken);
    }
}