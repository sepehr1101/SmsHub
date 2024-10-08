using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete
{
    public record DeleteConfigTypDto : IRequest
    {
        public short Id { get; init; }

    }
}
