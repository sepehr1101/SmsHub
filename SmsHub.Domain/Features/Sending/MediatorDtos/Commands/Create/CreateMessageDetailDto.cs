using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateMessageDetailDto : IRequest
    {
        public Guid MessagesHolderId { get; init; }
        public string? Receptor { get; init; }
        public long ProviderResult { get; init; }
        public DateTime SendDateTime { get; init; }
        public string? Text { get; init; }
        public short SmsCount { get; init; }
    }
}
