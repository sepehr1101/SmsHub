namespace SmsHub.Domain.Features.Security.Dtos
{
    public record GetUserLineByUserIdDto
    {
        public long Id { get; set; }
        public int LineId { get; set; }
        public string LineNumber { get; set; }
    }
}
