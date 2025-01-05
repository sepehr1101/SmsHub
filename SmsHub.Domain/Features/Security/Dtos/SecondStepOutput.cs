namespace SmsHub.Domain.Features.Security.Dtos
{
    public record SecondStepOutput
    {
        public string AccessToken { get; } = default!;
        public string RefreshToken { get; } = default!;
        public SecondStepOutput(string access, string refresh)
        {
            AccessToken = access;
            RefreshToken = refresh;
        }
    }
}
