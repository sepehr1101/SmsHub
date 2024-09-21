using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands
{
    public record CreateTemplateCategoryDto:IRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; } 
    }
}
