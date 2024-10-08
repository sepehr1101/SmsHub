using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete
{
    public record DeleteConsumerLineDto : IRequest
    {
        public int Id { get; init; }

    }
}
