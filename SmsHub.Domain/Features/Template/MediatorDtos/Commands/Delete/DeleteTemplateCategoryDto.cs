using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete
{
    public record DeleteTemplateCategoryDto : IRequest
    {
        public int Id { get; init; }
    }
}
