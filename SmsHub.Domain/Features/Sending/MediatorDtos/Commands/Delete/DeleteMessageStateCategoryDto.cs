using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete
{
    public record DeleteMessageStateCategoryDto : IRequest
    {
        public int Id { get; init; }
    }
}
