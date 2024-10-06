using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateLogLevelDto : IRequest
    {
        public string? Title { get; set; }
        public string? Css { get; set; }
    }
}
