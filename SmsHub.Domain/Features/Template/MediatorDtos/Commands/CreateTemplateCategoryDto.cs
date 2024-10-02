using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands
{
    public record CreateTemplateCategoryDto:IRequest
    {
        public string? Title { get; init; }
        public string? Description { get; init; } 
    }
}
