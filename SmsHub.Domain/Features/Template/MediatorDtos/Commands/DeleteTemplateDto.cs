using MediatR;

namespace SmsHub.Domain.Features.Template.MediatorDtos.Commands
{
    public record DeleteTemplateDto : IRequest
    {
        public int Id { get; init; }
    }
}
