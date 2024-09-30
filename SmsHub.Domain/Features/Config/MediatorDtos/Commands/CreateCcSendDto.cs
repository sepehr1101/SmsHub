using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record CreateCcSendDto : IRequest//todo: record or class?
    { 
        public int ConfigTypeGroupId { get; set; }
        public string? Mobile { get; set; } 
    }
}
