using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateInformativeLogDto : IRequest
    {
        public int LogLevelId { get; set; }
        public string? Section { get; set; }
        public string? Description { get; set; }
        public Guid? UserId { get; set; }
        public string? UserInfo { get; set; }
        public string? Ip { get; set; }
        public DateTime InsertDateTime { get; set; }
        public string? ClientInfo { get; set; }
    }
}
