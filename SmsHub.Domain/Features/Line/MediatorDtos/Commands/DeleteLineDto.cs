using MediatR;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands
{
    public record DeleteLineDto : IRequest
    {
        public int Id { get; init; }
    }
}
