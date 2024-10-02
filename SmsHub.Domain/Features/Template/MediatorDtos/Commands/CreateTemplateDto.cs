using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands
{
    public record CreateTemplateDto:IRequest
    {
        public string? Expression { get; init; }
        public string? Title { get; init; } 
        public int TemplateCategoryId { get; init; }
        public bool IsActive { get; init; }
        public string? Parameters { get; init; } 
        public int MinCredit { get; init; }
    }
}
