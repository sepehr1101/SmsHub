using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateMessageStateCategoryDto
    {
        public string Title { get; init; } = null!;
        public ProviderEnum ProviderId { get; init; }
        public bool IsError { get; init; }
        public string Css { get; init; } = null!;
    }
}
