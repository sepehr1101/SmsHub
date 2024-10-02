using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record DeleteConfigTypeGroupDto : IRequest
    {
        public int Id { get; init; }

    }
}
