namespace SmsHub.Domain.Features.Security.Dtos
{
    public class FirstStepLoginInput
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ClientDateTime { get; set; }
        public string AppVersion { get; set; } = default!;
        public string CaptchaText { get; set; } = null!;
        public string CaptchaToken { get; set; } = null!;
        public string CaptchaInputText { get; set; } = null!;
    }
}