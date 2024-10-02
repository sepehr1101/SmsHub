using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands
{
    public record DeleteTemplateCategoryDto : IRequest
    {
        public int Id { get; init; }
    }
}
