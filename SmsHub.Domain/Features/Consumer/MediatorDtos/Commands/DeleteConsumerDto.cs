using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record DeleteConsumerDto : IRequest
    {
        public int Id{ get; init; }
    }
}
