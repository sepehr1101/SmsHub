using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateConfigDto : IRequest
    {
        public int ConfigTypeGroupId { get; init; }
        public int TemplateId { get; init; }
    }
}
