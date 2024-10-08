using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateOperationTypeDto : IRequest
    {
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
}
