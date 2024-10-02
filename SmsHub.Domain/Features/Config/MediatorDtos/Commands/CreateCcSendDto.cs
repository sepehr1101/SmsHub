using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record CreateCcSendDto : IRequest
    { 
        public int ConfigTypeGroupId { get; init; }
        public string Mobile { get; init; } = null!; 
    }
}
