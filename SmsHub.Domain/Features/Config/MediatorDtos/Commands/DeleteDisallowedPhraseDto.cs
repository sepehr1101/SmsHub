using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record DeleteDisallowedPhraseDto : IRequest
    {
        public int Id { get; init; }

    }
}
