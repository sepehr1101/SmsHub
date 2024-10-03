using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageDetailDto : IRequest
    {
        public long Id { get; init; }
        public Guid MessagesHolderId { get; init; }
        public string Receptor { get; init; } = null!;
        public long ProviderResult { get; init; }
        public DateTime SendDateTime { get; init; }
        public string Text { get; init; } = null!;
        public short SmsCount { get; init; }
    }
}
