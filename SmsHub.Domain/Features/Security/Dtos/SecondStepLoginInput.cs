namespace SmsHub.Domain.Features.Security.Dtos
{
    public class SecondStepLoginInput
    {
        public Guid Id { get; set; }
        public string ConfirmCode { get; set; } = default!;
    }
}
