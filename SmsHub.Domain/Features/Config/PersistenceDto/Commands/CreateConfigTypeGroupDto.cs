using MediatR;

namespace SmsHub.Domain.Features.Config.PersistenceDto.Commands
{
    public record CreateConfigTypeGroupDto : IRequest//todo: record or class?
    {
        public short ConfigTypeId { get; set; }
        public string? Title { get; set; } 
        public string? Description { get; set; } 
    }
}
