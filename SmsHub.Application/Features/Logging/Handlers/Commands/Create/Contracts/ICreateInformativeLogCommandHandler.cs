using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts
{
    public interface ICreateInformativeLogCommandHandler
    {
        Task Handle(CreateInformativeLogDto request, CancellationToken cancellationToken);
    }
}