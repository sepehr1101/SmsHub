using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record DeleteConsumerLineDto : IRequest
    {
        public int Id { get; init; }

    }
}
