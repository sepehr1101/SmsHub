using MediatR;

namespace SmsHub.Domain.Features.Consumer.PersistenceDto.Commands
{
    public record CreateConsumerDto: IRequest
    { 
        public string? Title { get; init; }
        public string? Description { get; init; }
        public string? ApiKey { get; init; }
    }
}
