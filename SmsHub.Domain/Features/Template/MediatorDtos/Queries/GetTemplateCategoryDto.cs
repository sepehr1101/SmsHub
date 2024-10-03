using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Queries
{
    public record GetTemplateCategoryDto:IRequest
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
    }
}
