using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts
{
    public interface IInformativeLogDeleteHandler
    {
        Task Handle(DeleteInformativeLogDto deleteInformativeLogDto, CancellationToken cancellationToken);
    }
}
