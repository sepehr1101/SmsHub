using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateLogLevelDto : IRequest
    {
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
}
