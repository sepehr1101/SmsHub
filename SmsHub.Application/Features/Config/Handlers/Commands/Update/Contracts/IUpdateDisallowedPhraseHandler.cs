using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts
{
    public interface IUpdateDisallowedPhraseHandler
    {
        Task Handle(UpdateDisallowedPhraseDto updateDisallowedPhraseDto, CancellationToken cancellationToken);
    }
}
