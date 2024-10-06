using MediatR;
using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create
{
    public record CreateLineDto : IRequest
    {
        public ProviderEnum ProviderId { get; init; }
        public string? Number { get; init; }
        public string? Credential { get; init; }
    }
}
