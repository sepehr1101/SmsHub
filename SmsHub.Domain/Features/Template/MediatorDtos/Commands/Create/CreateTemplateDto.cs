using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create
{
    public record CreateTemplateDto : IRequest
    {
        public string Expression { get; init; } = null!;
        public string Title { get; init; } = null!;
        public int TemplateCategoryId { get; init; }
        public bool IsActive { get; init; }
        public string Parameters { get; init; } = null!; 
        public int MinCredit { get; init; }
    }
}
