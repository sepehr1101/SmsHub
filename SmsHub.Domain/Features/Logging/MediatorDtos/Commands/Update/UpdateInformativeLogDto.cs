namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update
{
    public record UpdateInformativeLogDto
    {//todo: check Prop
        public long Id { get; set; }
        public int LogLevelId { get; set; }
        public string Section { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? UserId { get; set; }
        public string? UserInfo { get; set; }
        public string Ip { get; set; } = null!;
        public DateTime InsertDateTime { get; set; }
        public string ClientInfo { get; set; } = null!;
    }
}
