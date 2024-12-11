namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public class MobileText
    {
        public string Mobile { get; set; } = default!;
        public string Text { get; set; } = default!;
    }
}
