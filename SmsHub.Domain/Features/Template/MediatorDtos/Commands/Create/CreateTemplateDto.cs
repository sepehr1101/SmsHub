using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create
{
    public record CreateTemplateDto : IRequest
    {
        public string? Expression { get; set; }
        public string? Title { get; set; }
        public int TemplateCategoryId { get; set; }
        public bool IsActive { get; set; }
        public string? Parameters { get; set; }
        public int MinCredit { get; set; }
    }
}
