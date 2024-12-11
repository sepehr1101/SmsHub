using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateOperationTypeDto  
    {
        public int Id { get; set; } 
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
}
