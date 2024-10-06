using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record UpdateMessageStateCategoryDto : IRequest
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public short Provider { get; init; }
        public bool IsError { get; init; }
        public string Css { get; init; } = null!;

    }
}
