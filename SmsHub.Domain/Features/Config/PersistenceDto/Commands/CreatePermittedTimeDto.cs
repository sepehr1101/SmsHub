using MediatR;

namespace SmsHub.Domain.Features.Config.PersistenceDto.Commands
{
    public record CreatePermittedTimeDto : IRequest//todo: record or class?
    {
        public int ConfigTypeGroupId { get; set; }
        public string? FromTime { get; set; }
        public string? ToTime { get; set; } 
    }
}
