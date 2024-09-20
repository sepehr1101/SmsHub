using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record CreateMessageDetailDto:IRequest
    {
        public Guid MessagesHolderId { get; set; }
        public string? Receptor { get; set; } 
        public long ProviderResult { get; set; }
        public DateTime SendDateTime { get; set; }
        public string? Text { get; set; } 
        public short SmsCount { get; set; }
    }
}
