namespace SmsHub.Domain.Features.Security.Dtos
{
    public record GetUserLineDto
    {
        public long Id { get; set; }
        public int LineId { get; set; }
        public Guid UserId { get; set; }
    }
}
