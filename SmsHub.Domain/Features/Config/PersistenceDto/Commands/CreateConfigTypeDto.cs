using MediatR;

namespace SmsHub.Domain.Features.Config.PersistenceDto.Commands
{
    public record CreateConfigTypeDto : IRequest//todo: record or class?
    {//todo : null or not?
        public string? Title { get; set; } 
        public string? Description { get; set; } 
    }
}
