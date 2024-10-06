using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete
{
    public record DeleteOperationTypeDto : IRequest
    {
        public int Id { get; init; }
    }
}
