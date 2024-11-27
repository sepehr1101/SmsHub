using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateLogLevelDto  
    {
        public int Id { get; set; } //todo: not identity
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
}
