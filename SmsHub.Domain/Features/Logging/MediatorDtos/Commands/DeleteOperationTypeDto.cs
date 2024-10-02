using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record DeleteOperationTypeDto : IRequest
    {
        public int Id { get; init; }
    }
}
