using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create
{
    public record CreateTemplateCategoryDto  
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
    }
}
