using MediatR;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete
{
    public record DeleteLineDto : IRequest
    {
        public int Id { get; init; }
    }
}
