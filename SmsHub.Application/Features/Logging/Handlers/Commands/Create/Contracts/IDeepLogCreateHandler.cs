using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts
{
    public interface IDeepLogCreateHandler
    {
        Task Handle(CreateDeepLogDto request, CancellationToken cancellationToken);
    }
}