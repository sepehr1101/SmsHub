namespace SmsHub.Domain.Features.Security.Dtos
{
    public record CreateUserLineDto
    {
        public int LineId { get; set; }
        public Guid UserId { get; set; }
    }
}
