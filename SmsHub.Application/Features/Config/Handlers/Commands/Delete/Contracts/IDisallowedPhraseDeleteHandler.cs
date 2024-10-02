using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts
{
    public interface IDisallowedPhraseDeleteHandler
    {
        Task Handle(DeleteDisallowedPhraseDto deleteDisallowedPhraseDto, CancellationToken cancellationToken);

    }
}
