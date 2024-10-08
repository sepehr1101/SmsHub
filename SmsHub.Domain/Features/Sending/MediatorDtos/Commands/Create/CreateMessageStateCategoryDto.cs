using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateMessageStateCategoryDto : IRequest
    {
        public string Title { get; init; } = null!;
        public short Provider { get; init; }
        public bool IsError { get; init; }
        public string Css { get; init; } = null!;
    }
}
