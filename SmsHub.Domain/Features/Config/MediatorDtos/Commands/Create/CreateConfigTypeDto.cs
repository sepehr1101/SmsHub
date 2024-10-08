using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateConfigTypeDto : IRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
