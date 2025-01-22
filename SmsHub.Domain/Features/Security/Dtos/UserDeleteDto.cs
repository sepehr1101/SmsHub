namespace SmsHub.Domain.Features.Security.Dtos
{
    public record UserDeleteDto
    {
        public Guid Id { get; set; }
        public string RemoveLogInfo { get; set; }
    }
}
