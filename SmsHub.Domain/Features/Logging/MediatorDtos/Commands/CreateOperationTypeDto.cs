using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record CreateOperationTypeDto:IRequest
    { //todo : everyone null?
        public string? Title { get; set; }
        public string Css { get; set; } 
    }
}
