using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete
{
    public record DeletePermittedTimeDto : IRequest
    {
        public int Id { get; init; }

    }
}
